using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : EnemyBehaviour {


    private void Awake()
    {
        ResetFireTime();
    }

    // Update is called once per frame
    void Update () {

        DropBomb();
        Move();
	}

    void DropBomb()
    {
        fireTime -= Time.deltaTime;

        if (fireTime <= 0)
        {
            //drop a bomb
            Instantiate(enemyWeapon, transform.position, transform.rotation);
            ResetFireTime();
        }
    }
    public void ResetFireTime()
    {
        fireTime = rateOfFire;
    }

}
