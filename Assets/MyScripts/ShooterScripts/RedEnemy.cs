using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : EnemyBehaviour {



	void Awake () {
        //find player
        target = GameObject.Find("PlayerTransform").transform;
	}
	
	// Update is called once per frame
	void Update () {

        //distanceToPlayer = Vector3.Distance(target.transform.position, transform.position);
        //Vector3 directToPlayer = target.transform.position - transform.position;
        //directToPlayer.x = 0;
        
       

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directToPlayer), 0.1f);

        Move();
	}
}
