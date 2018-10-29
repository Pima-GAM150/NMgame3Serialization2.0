using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSelection : MonoBehaviour {

    public int mainMenuIndex = 0;
    public int playerMetalScreen = 1;
    


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(playerMetalScreen);
            }

            if (gameObject == null)
            {
                SceneManager.LoadScene(playerMetalScreen);
            }




    }

    public void GameStart()
    {
        SceneManager.LoadScene(playerMetalScreen);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }

}


