using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRotate : MonoBehaviour {

    public float rotSpeed;


    private void Update()
    { 
    transform.Rotate(0,0,rotSpeed * Time.deltaTime);
	}
	
	
}
