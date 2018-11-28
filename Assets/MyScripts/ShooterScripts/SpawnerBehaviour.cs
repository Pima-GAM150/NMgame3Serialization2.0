using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerBehaviour : MonoBehaviour {

    public Rigidbody2D spawnItem;
    public Rigidbody2D spawnItem2;
    public float moveSpeed;

    public float speedOfTheSpawned;

    public float secondsBtwnSpawns;    
    [HideInInspector]
    public float spawnTimer;
    float spawnTimer2;

	// Use this for initialization
	void Start () {
        Timer1Reset();
        Timer2Reset();
        
    }
    

    public virtual void SpawnStuff()
    {

        spawnTimer -= Time.deltaTime;
        spawnTimer2 -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {

            Rigidbody2D item1Clone;
            item1Clone = Instantiate(spawnItem, transform.position, transform.rotation) as Rigidbody2D;
            item1Clone.velocity = transform.TransformDirection(Vector3.up * speedOfTheSpawned);
            Timer1Reset();
            
        }

        if (spawnTimer2 <= 0f)
        {
            Rigidbody2D item2Clone;
            item2Clone = Instantiate(spawnItem2, transform.position, transform.rotation) as Rigidbody2D;
            item2Clone.velocity = transform.TransformDirection(Vector3.up * speedOfTheSpawned);
            Timer2Reset();
        }

        
            
    }

    void Timer2Reset()
    {
        spawnTimer2 = secondsBtwnSpawns * Random.Range(2,7);
    }
    void Timer1Reset()
    {
        spawnTimer = secondsBtwnSpawns;
       
    }
    
}
