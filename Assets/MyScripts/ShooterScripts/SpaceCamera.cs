using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCamera : MonoBehaviour {

    public float speed;



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SpaceCameraMovement();
	}


    void SpaceCameraMovement()
    {
        float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(new Vector2(horiz, vert));

        ;
    }

}
