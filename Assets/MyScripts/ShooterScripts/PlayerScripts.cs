using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

    public Canvas playScreen;
    public Canvas endScreen;

    public int playerScore;

    public float speed;
    public float rotSpeed;
    public BulletShot projectile;
    public Transform barrel;
    public float speedOfProjectile;

    enum State { dead = 0, alive = 1 }
    State playerState;

    Transform mouseGuide;

	void Start () {

        playerScore = 0;

        FindObjectOfType<AudioManager>().PlayExtraSound("Theme1");
        playScreen.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);

        playerState = State.alive;

	}
	
	// Update is called once per frame
	void Update () {

        if (playerState == State.alive)
        {
            PlayerMovement();
            PlayerShoot();
        }
        else
        {
            PlayerSpriteCantMove();
        }

	}//end update

   void PlayerSpriteCantMove()
    {
        transform.Translate(new Vector2(0, 0));
        transform.Rotate(new Vector3(0, 0, 0));
    }




    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Firing with space");
            Rigidbody2D clone;
            clone = Instantiate(projectile.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.up * speedOfProjectile);
        }
    }


    void PlayerMovement()
    {
        float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed;
        float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(new Vector2(0, vert));
        transform.Rotate(new Vector3(0,0, -horiz));
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("I hit" + other.gameObject.name);
        if (other.gameObject.tag == "Enemy" || other.tag == "Enviornment")
        {

            playerState = State.dead;
            playScreen.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);

            

        }


    }


}
