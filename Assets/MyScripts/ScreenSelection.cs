using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSelection : MonoBehaviour {

    public Animator animator;

    int levelToLoad;
    public int mainMenuIndex = 0;
    public int metalScreen = 1;
    public int retroWaveScreen = 2;
    public int shooterGame = 3;
    public int trailerScene = 4;

    public int currentScreen;    
	
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
        levelToLoad = metalScreen;
        animator.SetTrigger("FadeOut");
    }


    public void RetroScreenStart()
    {
        levelToLoad = retroWaveScreen;
        animator.SetTrigger("FadeOut");
    }


    public void BackToMenu()
    {
        levelToLoad = mainMenuIndex;
        animator.SetTrigger("FadeOut");
    }

    public void ShooterGameStart()
    {
        levelToLoad = shooterGame;
        animator.SetTrigger("FadeOut");
    }

    public void TrailerStart()
    {
        levelToLoad = trailerScene;
        animator.SetTrigger("FadeOut");

    }

    public void FadeToLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Ejected");
        Application.Quit();
    }

}


