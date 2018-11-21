using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerBehaviour : MonoBehaviour {

    public Rigidbody2D spawnItem;
    public float moveSpeed;

    public float howFastThingsGetShotOutAt;

    public int secondsBtwnSpawns;

    public int secondsOfExistance;

    public float spawnTimer;


	// Use this for initialization
	void Start () {
        //StartCoroutine(ExistTime(secondsOfExistance));
        //StartCoroutine(SpawnAfterSeconds(secondsBtwnSpawns));
       
    }
    

    void Update () {
        SpawnStuff();
	}

    void SpawnStuff()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {

            Rigidbody2D clone;
            clone = Instantiate(spawnItem, transform.position, transform.rotation) as Rigidbody2D;
            TimerReset();
            
        }      
            
    }

    void TimerReset()
    {
        spawnTimer = secondsBtwnSpawns;
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
