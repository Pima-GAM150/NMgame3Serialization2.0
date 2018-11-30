using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour {

    
    public Rigidbody2D enemyWeapon;

    public float moveSpeed;
    public int pointWorth;
    public int secondsOfLife;


    [HideInInspector]
    public float distanceToPlayer;

    public float enemyProjectileSpeed;
    //used for time
    public float rateOfFire;
    [HideInInspector]
    public float fireTime;

    public delegate void EnemyDied(EnemyBehaviour enemy);
    public static event EnemyDied enemyDiedEvent;

    public virtual void Start()
    {
        StartCoroutine(DestroySelfAfter(secondsOfLife));
    }

    public virtual void Move()
    {       
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Enemy being hit by " + collision.name);
        if (collision.tag == "GreenBullet")
        {

            enemyDiedEvent(this);
            Destroy(gameObject);
        }
    }

    public void StrafeMove()
    {
        

        transform.Translate(moveSpeed * Time.deltaTime,0, 0);
    }

    IEnumerator DestroySelfAfter(int seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }

}
