using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSelection : MonoBehaviour {

    public int mainMenuIndex = 0;
    public int metalScreen = 1;
    public int retroWaveScreen = 2;
    public int shooterGame = 3;
    public int trailerScene = 4;

    public int currentScreen;


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

    public void ShooterGameStart()
    {
        SceneManager.LoadScene(shooterGame);
    }

    public void TrailerStart()
    {
        SceneManager.LoadScene(trailerScene);
    }


}


