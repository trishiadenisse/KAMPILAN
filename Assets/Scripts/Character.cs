﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Character : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 10f;
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown("space") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 700f);

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else 
            anim.SetBool("isRunning", false);

        if (rb.velocity.y == 0) {
            anim.SetBool("isJumping", false);
        }

        if (rb.velocity.y > 0) {
            anim.SetBool("isJumping", true); 
        }
    }

    private void FixedUpdate (){
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }
         

    private void LateUpdate (){
        if (dirX > 0 || Input.GetKeyDown("d"))
            facingRight = true;
        else if (dirX < 0 || Input.GetKeyDown("a"))
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x >0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
}
