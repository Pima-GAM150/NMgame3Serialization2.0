using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : EnemyBehaviour {

    // Use this for initialization
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            target = GameObject.FindObjectOfType<PlayerScripts>().gameObject.transform;
            StrafeMove();
            ShootLazer();

        }
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
