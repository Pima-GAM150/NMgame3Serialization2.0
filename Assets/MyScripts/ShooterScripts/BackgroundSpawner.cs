using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : SpawnerBehaviour
{
    
    public float maxMoveTime; 
    private float moveTimer;

    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveSideToSide();
        
    }
    
    void MoveSideToSide()
    {
        moveTimer -= Time.deltaTime;


        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

        if (moveTimer <= 0f)
        {
            //turn arounds
            moveSpeed *= -1;

            ResetTime();
        }
    }

    void ResetTime()
    {
        moveTimer = maxMoveTime;
    }
}


///do a movement left and right and itll be farther back in the distance