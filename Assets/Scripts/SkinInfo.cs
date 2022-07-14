using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class SkinInfo : ScriptableObject  
{
    public enum SkinIDs {pink, red, yellow, green, blue, turqoise, purple, orange, brown, grey, galaxy, silver, gold, transparent}
    public SkinIDs skinID;

    public Sprite skinSprite;

    public int skinPrice;

}
