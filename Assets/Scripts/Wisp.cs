using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class Wisp : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    private bool playerDetected;
    #endregion

    #region Physics_components
    Rigidbody2D WispRB;
    #endregion

    #region Targeting_variables
    private Transform player;
    #endregion

    #region Light_variables
    public float stealAmount;
    private float lifeLength;
    #endregion

    #region Random_variables
    public float latestDirChangeTime;
    public float dirChangeTime = 2f;
    #endregion


    void Start() {
        movespeed = movespeed * Random.Range(1f, 2f);
        player = GameObject.Find("Player").transform;
        Debug.Log(player);

        latestDirChangeTime = 0f;
        lifeLength = Random.Range(2.0f, 9.0f);
        playerDetected = false;

        WispRB = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
        if (playerDetected) {
            Debug.Log("RegMove");
            RegMove();
        }
        
        else {
            if (Time.time - latestDirChangeTime > dirChangeTime){
                Debug.Log("time shift thing");
                latestDirChangeTime = Time.time;
                newMoveVector();
        }
            // Debug.Log("RandMove");
            RandMove();
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
        Debug.Log(player.position);
        Vector2 movementDirection = player.position - transform.position;
        WispRB.velocity = movementDirection.normalized * movespeed;
    }

    #region CollisionFunctions
    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("yo");
        if (c.gameObject.CompareTag("Light"))
        {
            Debug.Log("YO");
            playerDetected = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D c) {
        if (c.transform.CompareTag("Player"))
        {
            c.transform.GetComponent<Player>().ChangeLight(-stealAmount);
        }
    }
    #endregion
}
