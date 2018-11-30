using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    
    public Rigidbody2D enemyWeapon;

    public float moveSpeed;
    public int pointWorth;
    [HideInInspector]
    public float distanceToPlayer;

    public float enemyProjectileSpeed;
    //used for time
    public float rateOfFire;
    [HideInInspector]
    public float fireTime;

 

    public virtual void Move()
    {       
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {

            
            Destroy(gameObject);
        }
    }

    public void StrafeMove()
    {
        

        transform.Translate(moveSpeed * Time.deltaTime,0, 0);
    }

}
