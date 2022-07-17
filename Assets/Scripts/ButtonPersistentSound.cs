using UnityEngine;

public class ButtonPersistentSound : MonoBehaviour
{
    //i have no idea what is going on
    
    private AudioSource normalClick;
    public int hashcode;

    void Awake()
    {
        if (PlayerPrefs.GetInt("currentPersistHash") == 0)
        {
            PlayerPrefs.SetInt("currentPersistHash", this.gameObject.GetHashCode());
        }
        
        ButtonPersistentSound[] collection = FindObjectsOfType<ButtonPersistentSound>();

        if (collection.Length == 1)
        {
            PlayerPrefs.SetInt("currentPersistHash", this.gameObject.GetHashCode());
        }
        
        //by right the original one's hashcode should be stored in playerprefs
        //compare the hashcode of every instance, if they are not the same as the stored one
        //then delete it, so by right the only instance left over is the original one
        //this ensures that unity does not keep spawning more every time scene changes
        foreach (ButtonPersistentSound obj in collection)
        {
            if(obj.gameObject.GetHashCode() != PlayerPrefs.GetInt("currentPersistHash")) // avoid deleting the object running this check
            {
                //Debug.Log("Deleting dupe " + obj.gameObject.GetHashCode());
                Destroy(obj.gameObject);
                return;
            }
            else
            {
                //idk why but this object (should be the original object if this part is executed)
                //do not have the same hashcode as the original hashcode stored in playerprefs
                
                //Debug.Log("i am " + obj.gameObject.GetHashCode());
                //Debug.Log("stored: " + PlayerPrefs.GetInt("currentPersistHash"));
                hashcode = obj.gameObject.GetHashCode();
                DontDestroyOnLoad(this.gameObject);
                
                normalClick = obj.GetComponent<AudioSource>(); //NOTE: DO NOT USE the keyword "this", use "obj"
            }
        }
    }
    

    //at least there are no more null pointer errors
    //worse case is no button sound but everything else works ok
    public void playNormalClick()
    {
        normalClick.volume = 0.15f; //i accidentally made the clip's volume too high
        normalClick.PlayOneShot(normalClick.clip);
    }
}
