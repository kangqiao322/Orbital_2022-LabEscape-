using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class SkinInfo : ScriptableObject  
{
    public enum SkinIDs {pink, red, green, purple, orange, bronze, silver, gold, crystal, rainbow}
    public SkinIDS skinID;

    public Sprite skinSprite;

    public int skinPrice;

}
