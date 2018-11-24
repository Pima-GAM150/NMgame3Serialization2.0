using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    
    public Rigidbody2D enemyWeapon;

    public float moveSpeed;
    public int pointWorth;
    [HideInInspector]
    public float distanceToPlayer;
    public Transform target;


    public enum State { isFlee = 0, isAttack= 1}
    public State enemyState;


    public virtual void Move()
    {
        Vector2 directToPlayer = target.transform.position - transform.position;
        //transform.rotation = Quaternion.Slerp(transform.rotation, , 0.1f);

        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }
}
