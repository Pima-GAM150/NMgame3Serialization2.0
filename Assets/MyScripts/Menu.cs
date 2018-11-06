using UnityEngine.Audio;
using UnityEngine;


public class Menu : MonoBehaviour {
    

    public int loadCount = 0;


	void Start () {
        loadCount++;
        PlayMusic();
	}
	
	// Update is called once per frame
	void Update () {
       
	}


    void PlayMusic()
    {
        if (loadCount > 1)
        {
            FindObjectOfType<AudioManager>().PlayExtraSound("2ndMenuMusic");
        }
        else FindObjectOfType<AudioManager>().PlayExtraSound("MenuMusic");
    }


}
