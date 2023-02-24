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
    private static bool playerDetected;
    #endregion

    #region Physics_components
    Rigidbody2D ShadeRB;
    #endregion

    #region Targeting_variables
    public Transform player;
    #endregion

    #region Attack_variables
    public float attackAmount;
    private float lifeLength;
    #endregion

    #region Random_variables
    public float latestDirChangeTime;
    public float dirChangeTime = 2f;
    
    #endregion

    void Awake() {
        latestDirChangeTime = 0f;
        lifeLength = Random.Range(2.0f, 9.0f);
        playerDetected = false;

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
        Vector2 movementDirection = player.position - transform.position;
        ShadeRB.velocity = movementDirection.normalized * movespeed;
    }

    public static void DetectedPlayer()
    {
        playerDetected = true;
    }

    public static void NotDetectedPlayer()
    {
        playerDetected = false;
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
