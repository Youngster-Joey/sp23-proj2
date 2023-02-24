using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class Shade : MonoBehaviour
{
     #region Movement_variables
    public float movespeed;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public float movespeedRampTimer;
    private float nextMovespeedRamp;
    #endregion

    #region Physics_components
    Rigidbody2D ShadeRB;
    #endregion

    #region Targeting_variables
    private GameObject playerObject;
    private Transform player;
    #endregion

    #region Attack_variables
    public float attackAmount;
    #endregion

    #region Random_variables
    public float latestDirChangeTime;
    public float dirChangeTime = 2f;
    
    #endregion

    void Awake() {
        latestDirChangeTime = 0f;

        playerObject = GameObject.Find("Player");
        player = playerObject.transform;

        ShadeRB = GetComponent<Rigidbody2D>();

        nextMovespeedRamp = movespeedRampTimer;
    }

    void Update() {
                
        if (player.GetComponent<Player>().lightRadius < 1) {
            RegMove();
        }

        else {
            if (Time.time - latestDirChangeTime > dirChangeTime){
                Debug.Log("time shift thing");
                latestDirChangeTime = Time.time;
                newMoveVector();
        }
            RandMove();
        }

        nextMovespeedRamp -= Time.deltaTime;
        if (nextMovespeedRamp < 0) {
            movespeed += 0.1f;
            nextMovespeedRamp = movespeedRampTimer;
        }
        
    }



    void newMoveVector() {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * movespeed;
    }
    
    private void RandMove() {
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), 
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }

    private void RegMove() {
        Vector2 movementDirection = player.position - transform.position;
        ShadeRB.velocity = movementDirection.normalized * movespeed;
    }

    #region CollisionFunctions
    private void OnCollisionEnter2D(Collision2D c)
    {

        if (c.transform.gameObject.CompareTag("Player"))
        {
            c.transform.GetComponent<Player>().TakeDamage((int) attackAmount);
        }
    }
    #endregion
}
