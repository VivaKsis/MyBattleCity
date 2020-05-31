using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private Vector2 movement;

    public int id = 1;

    private void Start()
    {
        rb.rotation = 0f;
        Weapon weapon = gameObject.GetComponentInChildren<Weapon>();
        weapon.firePointId = id;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("AorD");
        movement.y = Input.GetAxisRaw("WorS");
        SetDirection();

        if (Input.GetButtonDown("Fire1"))
        {
            GameEvents.current.MustShoot(id);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void SetDirection ()
    {
        if (movement.x < 0)
        {
            rb.SetRotation(180f);
        } else if (movement.x > 0)
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
}
