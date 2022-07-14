using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPersistentSound : MonoBehaviour
{

    //i want to kms
    private static ButtonPersistentSound _instance = null;
    public static ButtonPersistentSound Instance
    {
        get { return _instance; }
    }
    
    private AudioSource normalClick;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            //Debug.Log("Destroyed " + this.GetHashCode());
            Destroy(this.gameObject);
            return;
        }
        else
        {
            //Debug.Log(this.GetHashCode());
            _instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);
        
        normalClick = GetComponent<AudioSource>();
        //Debug.Log(normalClick);
    }

    //at least there are no more null pointer errors
    //worse case is no button sound but everything else works ok
    public void playNormalClick()
    {
        //Debug.Log(normalClick);
        
        normalClick.PlayOneShot(normalClick.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
