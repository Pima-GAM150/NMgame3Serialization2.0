using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour {

    public int secondsTilDeath;

    // Use this for initialization
    void Start () {

        StartCoroutine(DestroyAfterSeconds(secondsTilDeath));

    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator DestroyAfterSeconds(int seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {// what happens when this bullet hits something with a trigger

        if (trigger.tag != "PlayerSprite")
        {//if if hits anything it destroys itself;
            Destroy(gameObject);
        }
        if (trigger.tag == "Enemy")
        {// if the target is an enemy it will take the the trigger and get the enemy script and take the point worth and find the player and add the points to its splayerscore
            FindObjectOfType<PlayerScripts>().playerScore =+ trigger.GetComponent<EnemyBehaviour>().pointWorth;
        }

        if (trigger.tag == "Enviornment")
        {//add a small amount 
            FindObjectOfType<PlayerScripts>().playerScore = + 50;
        }

    }


}
