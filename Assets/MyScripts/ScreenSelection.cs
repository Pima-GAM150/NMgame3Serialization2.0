using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSelection : MonoBehaviour {

    public int mainMenuIndex = 0;
    public int metalScreen = 1;
    public int retroWaveScreen = 2;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(mainMenuIndex);
            }

            if (gameObject == null)
            {
                SceneManager.LoadScene(mainMenuIndex);
            }




    }

    public void MetalScreenStart()
    {
        SceneManager.LoadScene(metalScreen);

    }


    public void RetroScreenStart()
    {
        SceneManager.LoadScene(retroWaveScreen);
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }

}


