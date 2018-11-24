using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : EnemyBehaviour {
    


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        FindPlayer();

        if (enemyState == State.isAttack)
            FindPlayer();
        else RunAway();
       

        


	}

    void RunAway()
    {
        target = GameObject.FindObjectOfType<BackgroundSpawner>().gameObject.transform;
        Move();
    }


    void FindPlayer()
    {
        target = GameObject.Find("Player1").transform;
        distanceToPlayer = Vector3.Distance(target.transform.position, gameObject.transform.position);
        if (distanceToPlayer > 10)
        {
            //Vector2 directToPlayer = target.transform.position - transform.position;
            //transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, 0.1f);

            Move();
            

            //if (directToPlayer.magnitude < 3)
            //{
            //    enemyState = State.isFlee;
            //}
            //else enemyState = State.isAttack;

        }

    }
}
