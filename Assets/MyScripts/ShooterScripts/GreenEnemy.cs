using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : EnemyBehaviour {



    private void Awake()
    {
        target = FindObjectOfType<PlayerScripts>().gameObject.transform;
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
            Instantiate(enemyWeapon, transform.position, transform.rotation);
            ResetFireTime();
        }
    }
    

    public void ResetFireTime()
    {
        fireTime = rateOfFire;
    }

}
