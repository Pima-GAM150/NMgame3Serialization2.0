using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCounter : MonoBehaviour {


    public static SceneCounter singleton;
    public int sceneCount;

	void Start () {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(singleton);
        }
        else Destroy(singleton);

           
	}

    private void Update()
    {
        OnLevelWasLoaded(0);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            sceneCount++;
        }
    }

}
