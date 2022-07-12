using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
 
public class SpriteSwaper : EditorWindow
{
    AnimationClip clip;
    AnimationCurve curve;
    Texture2D tex;
    Texture2D oldTex;
    public Sprite[] sprites;
 
    [MenuItem ("Custom/Sprite  Swaper")]
    static void Init () {
        // Get existing open window or if none, make a new one:      
        EditorWindow.GetWindow(typeof(SpriteSwaper));
    }
 
    void OnGUI()
    {
        //Position GUI elements in a column
        GUILayout.BeginVertical();
        GUILayout.Label("Select animation to transpose");
        //Gets the animation clip to transpose
        clip = (AnimationClip)EditorGUILayout.ObjectField(clip, typeof(AnimationClip),true);
        GUILayout.Label("Select sprite sheet");
        //Gets the new sprite texture
        tex = (Texture2D)EditorGUILayout.ObjectField(tex, typeof(Texture2D),true);
 
        if(tex != oldTex)
        {
            //Grabs the texture asset and fills the sprite array with the sprites
            //Serializes it and displays it so you can see the sprites in the array
            string spriteSheet = AssetDatabase.GetAssetPath( tex );
            sprites = AssetDatabase.LoadAllAssetsAtPath( spriteSheet ).OfType<Sprite>().ToArray();
            oldTex = tex;
        }
        //Displays array in window.
        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty spritesProp = so.FindProperty("sprites");
        EditorGUILayout.PropertyField(spritesProp, true);
 
        //Button that starts the transpose.
        if(GUILayout.Button("Create New Animation"))
        {
            CreateNewAnimation();
        }
        GUILayout.EndVertical();
       
    }
 
    void CreateNewAnimation()
    {
        string[] splitName;
        AnimationClip clonedClip;
        //Checks to see if folder you wish to drop them in exists. I create a folder named after the texture.
        //YOU MUST CHANGE THIS TO REFERENCE A FOLDER STRUCTURE IN YOUR PROJECT.
        if(!AssetDatabase.IsValidFolder("Assets/Animations/Bystander/"+tex.name))
        {
            AssetDatabase.CreateFolder("Assets/Animations/Bystander",tex.name);
        }
        //Copies origional animation clip and assigns it to a retrieves the copied animation clip.
        AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(clip), "Assets/Animations/Bystander/"+tex.name + "/" + tex.name + clip.name + ".anim");
        clonedClip = (AnimationClip)AssetDatabase.LoadAssetAtPath("Assets/Animations/Bystander/"+tex.name + "/" + tex.name + clip.name + ".anim", typeof(AnimationClip));
       
        //This works with just a sprite animation.  I have not needed to use this with multiple object curves so I do not know how it would react with multiple object curves.  It will not copy float curves in its current state.
        //Gets the bindings for object curves
        foreach(var binding in AnimationUtility.GetObjectReferenceCurveBindings(clonedClip))
        {
            //Gets the keyframes and assigns them to an array
            ObjectReferenceKeyframe[] keyframes = AnimationUtility.GetObjectReferenceCurve(clonedClip,binding);
            for(int i = 0; i < keyframes.Length; i ++)
            {
                //Get the "_#" from the origional sprite  ImageA_01 gets 01
                splitName = keyframes[i].value.name.Split('_');
                //Uses LINQ to capture the sprite on from the sprite array we created earlier and sets the keyframe value to the new sprite
                keyframes[i].value = sprites.Where(x => x.name.Contains("_"+splitName[1])).First();
            }
            //Assigns the curve to the new animation clip
            AnimationUtility.SetObjectReferenceCurve(clonedClip, binding, keyframes);
        }
        //Saves and refreshes the database.
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
