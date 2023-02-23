using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private CircleCollider2D cc;
    private Animator animator;
    #endregion

    #region MovementVariables
    private float xMove;
    private float yMove;
    public float movespeed;
    #endregion

    #region LightVariables
    private float lightRadius;
    private CircleCollider2D lightCollider;
    private GameObject lightRing;
    #endregion

    #region KeyVariables
    private bool hasKey;
    #endregion

    #region HealthVariables
    public int health;
    #endregion

    #region UnityFunctions
    // Start is called before the first frame update
    public void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();

        lightRadius = 1.5f;
        lightRing = transform.Find("Light").gameObject;
        lightCollider = lightRing.GetComponent<CircleCollider2D>();

        hasKey = false;
    }

    // Update is called once per frame
    public void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        Vector2 movementVector = new Vector2(xMove, yMove).normalized;
        movementVector = movementVector * movespeed;
        rb.velocity = movementVector;

        if (Input.GetKeyDown(KeyCode.Space)) {
            ChangeLight(0.5f);
        }
        
    }
    #endregion

    #region LightFunctions
    public void ChangeLight(float amount) {
        lightRadius += amount;

        lightRing.transform.localScale = new Vector3(lightRadius, lightRadius, 1);

        // lightCollider.radius = lightRadius / 2;

        if (lightRadius < 0) {
            lightRadius = 0.5f;
        }
    }
    #endregion

    #region KeyFunctions
    public void GotKey()
    {
        hasKey = true;
    }

    public bool HasKey()
    {
        return hasKey;
    }
    #endregion


    #region HealthFunctions
    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(this.gameObject);
    }
    #endregion
}
