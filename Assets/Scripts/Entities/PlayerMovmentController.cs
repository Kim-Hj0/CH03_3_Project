using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovmentController : MonoBehaviour   //이동 관련된
{
    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    //점프
    private bool _isGrounded;
    private float jumpForce = 10f;


    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

 
    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.OnJumpEvent += Jump;    //점프
    }

    private void Update()   //점프
    {
        if (_isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }
    }


    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
    }


    private void OnCollisionEnter2D(Collision2D collision)  //점프
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)   //점프
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }


    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * 5;
        _rigidbody.velocity = direction;
    }


    private void Jump() //점프
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}
