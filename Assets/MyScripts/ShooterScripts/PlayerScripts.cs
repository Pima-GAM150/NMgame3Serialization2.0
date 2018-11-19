using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

    
    public float speed;
    public BulletShot projectile;
    public Transform barrel;

    Transform mouseGuide;

	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
        PlayerMovement();

        PlayerShoot();
	}//end update

   




    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Firing with space");
            Rigidbody2D clone;
            clone = Instantiate(projectile.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.up * 10);
        }
    }


    void PlayerMovement()
    {
        float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(new Vector2(horiz, vert));
        transform.Rotate(new Vector2(horiz,0));
        
    }



}
