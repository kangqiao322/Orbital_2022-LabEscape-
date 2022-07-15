using UnityEngine;

public class PokemonSound : MonoBehaviour
{
    
    private AudioSource littleRoot;
    public int hashcode;

    void Awake()
    {
        if (PlayerPrefs.GetInt("currentPokemonHash") == 0)
        {
            PlayerPrefs.SetInt("currentPokemonHash", this.gameObject.GetHashCode());
        }
        
        PokemonSound[] collection = FindObjectsOfType<PokemonSound>();

        if (collection.Length == 1)
        {
            PlayerPrefs.SetInt("currentPokemonHash", this.gameObject.GetHashCode());
        }
        
        //ensures that the pokemon music played is continuous from main menu -> shop
        //since only the original first instance is kept and all other dupes are deleted
        //NOTE: DO NOT USE the keyword "this", use "obj"
        foreach (PokemonSound obj in collection)
        {
            if(obj.gameObject.GetHashCode() != PlayerPrefs.GetInt("currentPokemonHash")) // avoid deleting the object running this check
            {
                Debug.Log("Deleting dupe " + obj.gameObject.GetHashCode());
                Destroy(obj.gameObject);
                return;
            }
            else
            {
                //idk why but this object (should be the original object if this part is executed)
                //do not have the same hashcode as the original hashcode stored in playerprefs
                
                //Debug.Log("i am " + obj.gameObject.GetHashCode());
                //Debug.Log("stored: " + PlayerPrefs.GetInt("currentPokemonHash"));
                hashcode = obj.gameObject.GetHashCode();
                DontDestroyOnLoad(obj.gameObject);

                // if (littleRoot != null)
                // {
                //     littleRoot.loop = true;
                //     littleRoot.volume = 0.15f;
                //
                //     if (!littleRoot.isPlaying)
                //     {
                //         littleRoot.PlayOneShot(littleRoot.clip);
                //     }
                // }
                
            }
            
            //Debug.Log("i am " + obj.gameObject.GetHashCode()); //NOTE: DO NOT USE the keyword "this", use "obj"
            littleRoot = obj.GetComponent<AudioSource>();
            littleRoot.playOnAwake = true;
            littleRoot.UnPause();

            if (!littleRoot.isPlaying) 
            {
                littleRoot.PlayOneShot(littleRoot.clip);
            }
        
            //Debug.Log(littleRoot.isPlaying);
        }
    }

    public void pausePokemon()
    {
        littleRoot.Pause();
    }
}
