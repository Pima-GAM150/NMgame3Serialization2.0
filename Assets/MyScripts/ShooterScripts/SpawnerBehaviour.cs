using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerBehaviour : MonoBehaviour {

    public Rigidbody2D spawnItem;
    public Rigidbody2D spawnItem2;
    public float moveSpeed;

    public float howFastThingsGetShotOutAt;

    public int secondsBtwnSpawns;    

    public float spawnTimer;
    float spawnTimer2;

	// Use this for initialization
	void Start () {
        //StartCoroutine(ExistTime(secondsOfExistance));
        //StartCoroutine(SpawnAfterSeconds(secondsBtwnSpawns));
        TimerReset();
    }
    

    void Update () {
        SpawnStuff();
	}

    public virtual void SpawnStuff()
    {
        spawnTimer -= Time.deltaTime;
        spawnTimer2 -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {

            Rigidbody2D item1Clone;
            item1Clone = Instantiate(spawnItem, transform.position, transform.rotation) as Rigidbody2D;
            item1Clone.velocity = transform.TransformDirection(Vector3.up);
            TimerReset();
            
        }

        if (spawnTimer2 <= 0f)
        {
            Rigidbody2D item2Clone;
            item2Clone = Instantiate(spawnItem2, transform.position, transform.rotation) as Rigidbody2D;
            item2Clone.velocity = transform.TransformDirection(Vector3.up);
            TimerReset();
        }

        
            
    }

    void TimerReset()
    {
        spawnTimer = secondsBtwnSpawns;
        spawnTimer2 = secondsBtwnSpawns * 2;
    }




    //IEnumerator SpawnAfterSeconds(int seconds)
    //{
    //    while (true)
    //    {
            
    //        yield return new WaitForSeconds(seconds);

    //        Rigidbody2D clone;
    //        clone = Instantiate(spawnItem.GetComponent<Rigidbody2D>(), transform.position, transform.rotation) as Rigidbody2D;
    //        clone.velocity = transform.TransformDirection(Vector3.up * howFastThingsGetShotOutAt);
            
            
    //        break;
    //    } 
    //}

    //IEnumerator ExistTime(int seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    Destroy(gameObject);
    //}
}
