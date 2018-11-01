using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRotate : MonoBehaviour {

    public float rotSpeed;
    public float forwardSpeed;

    private void Update()
    { 
        transform.Rotate(0,0,rotSpeed * Time.deltaTime);
        transform.Translate(0, 0, - forwardSpeed* Time.deltaTime);
	}
	
	
}
