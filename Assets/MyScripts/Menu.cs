using UnityEngine.Audio;
using UnityEngine;


public class Menu : MonoBehaviour {
    



	void Start () {
        
        PlayMusic();
	}
	
	// Update is called once per frame
	void Update () {
       
	}


    void PlayMusic()
    {
        if (FindObjectOfType<SceneCounter>().sceneCount > 1)
        {
            FindObjectOfType<AudioManager>().PlayExtraSound("2ndMenuMusic");
        }
        else FindObjectOfType<AudioManager>().PlayExtraSound("MenuMusic");
    }


}
