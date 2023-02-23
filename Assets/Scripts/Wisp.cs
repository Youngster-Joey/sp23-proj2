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
    Rigidbody2D EnemyRB;
    #endregion

    #region Targeting_variables
    public Transform player;
    #endregion

    #region Light_variables
    public float stealAmount;
    private float lifeLength;
    #endregion

    #region Random_variables
    public float latestDirChangeTime;
    public float DirChangeTime = 2f;
    
    #endregion

    void Awake() {
        latestDirChangeTime = 0f;
        lifeLength = Random.Range(2.0f, 9.0f);

    }

    void Update() {
        if (playerDetected) {
            RegMove();
        }
        RandMove();
    }



    void newMoveVector() {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * movespeed;
    }
    
    private void RandMove() {

    }

    private void RegMove() {

    }
}
