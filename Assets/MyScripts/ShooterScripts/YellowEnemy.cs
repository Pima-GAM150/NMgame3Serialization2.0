using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : EnemyBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            target = GameObject.FindObjectOfType<PlayerScripts>().gameObject.transform;

            Vector3 directToPlayer = target.position - transform.position;
            directToPlayer.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directToPlayer), 0.1f);
        }
    }

}
