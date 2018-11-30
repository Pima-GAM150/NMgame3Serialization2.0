using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidandStar : MonoBehaviour {

    public float speed;
    public int existanceTime;
    public int size;

	// Use this for initialization
	void Awake () {
        StartCoroutine(DestroyAfterSeconds(existanceTime));
	}
	
	// Update is called once per frame
	void Update () {
        MoveStraight();
        LifeCheck();
	}

    void MoveStraight()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    void LifeCheck()
    {
        if (size <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterSeconds(int seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GreenBullet")
        {
            size -= 1;
        }
        
    }


}
