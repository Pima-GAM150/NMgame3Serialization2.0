using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingSpawn : SpawnerBehaviour {
    
    public Transform centerOfOrbit;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(centerOfOrbit.position, Vector3.back, moveSpeed * Time.deltaTime);
    }
}
