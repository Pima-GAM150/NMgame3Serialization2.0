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

        if (gameObject.tag != "GreenBullet")
        {
           
        }
        else
        {
            if (trigger.tag != "PlayerSprite")
            {
                Destroy(gameObject);
            }
        }

    }


}
