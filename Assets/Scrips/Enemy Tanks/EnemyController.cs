using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public EnemyStats[] enemyType;
    private EnemyStats thisType;

   // public GameObject PatrolPoint2;
   //public GameObject PatrolPoint1;
    //private GameObject currentPatrol;

    private float moveSpeed;
    private float fireSpeed;

    private int healthPoints;
    private int score;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject explosionAnimation;

    private Vector2 movement;

    public static int maxEnemyId = 3;
    public int currentId;

    private void Start ()
    {
        SetParam();
        rb.rotation = 0f;
        movement.y = -1f;
    }

    public void SetParam ()
    {
        int r = Random.Range(0, enemyType.Length);
        thisType = enemyType[r];
        moveSpeed = thisType.moveSpeed;
        fireSpeed = thisType.fireSpeed;
        healthPoints = thisType.healthPoints;
        score = thisType.score;
        int i = thisType.design.Length;
        sr.sprite = thisType.design[i-1];

        currentId = maxEnemyId;
        maxEnemyId++;

        Weapon weapon = gameObject.GetComponentInChildren<Weapon>();
        weapon.firePointId = currentId;
    }

    void Update()
    {
        SetDirection();
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void SetDirection()
    {
        if (movement.x < 0)
        {
            rb.SetRotation(180f);
        }
        else if (movement.x > 0)
        {
            rb.SetRotation(0f);
        }
        if (movement.y < 0)
        {
            rb.SetRotation(270f);
        }
        else if (movement.y > 0)
        {
            rb.SetRotation(90f);
        }
    }

    public void TakeDamage(Vector3 hitposition)
    {
        healthPoints--;
        if (healthPoints<=0)
        {
            DestroyTank();
        }    
        else if (thisType.name == "Armored")
        {
            sr.sprite = thisType.design[healthPoints-1];
        }
    }

    private void DestroyTank()
    {
        GameObject explosion = Instantiate(explosionAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosion, 0.5f);
    }
}
