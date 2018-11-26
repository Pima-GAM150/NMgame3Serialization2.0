using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineCamera : MonoBehaviour {

    Camera myCamera;
    Vector3 cameraPos;
    public float speed;

	// Use this for initialization
	void Start () {
        myCamera = FindObjectOfType<Camera>();
        FindObjectOfType<AudioManager>().PlayExtraSound("MainTheme");

        
    
	}
	
	// Update is called once per frame
	void Update () {
        myCamera.transform.Translate(0, 0, -speed * Time.deltaTime);
	}





}
