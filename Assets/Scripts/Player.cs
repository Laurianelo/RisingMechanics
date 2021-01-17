using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce;
    private bool isDraging = false;
    private Vector2 touchPos;
    private Vector2 playerPos;
    private Vector2 dragPos;
    public float gravity = 1f;
    public float jumpHeight = 10f;
     
    //to improve 
    private float boundXLefy = -5.4f; 
    private float boundXRight = 5.4f; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AddGravity();
        GetInput();
        MovePlayer();

    }

    private void MovePlayer()
    {
        if(isDraging == true)
        {
            dragPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = new Vector2(playerPos.x + (dragPos.x - touchPos.x), transform.position.y);

            if(transform.position.x < boundXLefy)
            {
                transform.position = new Vector2(boundXLefy, transform.position.y);
            }
            else if (transform.position.x > boundXRight)
            {
                transform.position = new Vector2(boundXRight, transform.position.y);
            }
        }
    }

    private void GetInput()
    {
       if(Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            touchPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            playerPos = transform.position;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDraging = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("step"))
        {
            if(rb.velocity.y <= 0f)
            {
                jumpForce = gravity * jumpHeight;
                 rb.velocity = new Vector2(0, jumpForce);
            }
           
        }
    }

    void AddGravity()
    {
      // rb.gravityScale = gravity;
       rb.velocity = new Vector2(0, rb.velocity.y - (gravity * gravity));
    }

  
}
