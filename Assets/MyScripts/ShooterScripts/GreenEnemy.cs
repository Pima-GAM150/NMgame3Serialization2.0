using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : EnemyBehaviour {



    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update () {
        Move();
        ShootLazer();
       

        


	}

    void ShootLazer()
    {
        fireTime -= Time.deltaTime;

        if (fireTime <= 0)
        {
            Rigidbody2D clone;
            clone = Instantiate(enemyWeapon, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.up * enemyProjectileSpeed);

            ResetFireTime();
        }
    }
    

    public void ResetFireTime()
    {
        fireTime = rateOfFire;
    }

}
