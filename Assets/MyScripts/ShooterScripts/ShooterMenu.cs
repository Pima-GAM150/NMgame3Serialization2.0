using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMenu : MonoBehaviour {

    public PlayerScripts player;
    public Camera theActiveCamera;
    public Camera playerCam;
    public Canvas playScreen;
    public Canvas endScreen;
   


	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<PlayerScripts>();

	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
        {//makes a new camera
            theActiveCamera = new Camera();

            //if the player is null then it should set active the buttons to restart, save the score quit is always active
            endScreen.enabled = true;
            playScreen.enabled = false;


        }
        else
        {
            playScreen.enabled = true;
            endScreen.enabled = false;
        }
	}




}
