using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {

    GameObject targetPlayer;



	void Start () {
        targetPlayer = GameObject.FindObjectOfType<PlayerScripts>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 directToPlayer = targetPlayer.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, 0.1f);
    }
}
