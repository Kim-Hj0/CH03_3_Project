using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovmentController : MonoBehaviour   //�̵� ���õ�
{
    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;



    //����
    private bool _isGrounded;
    private float jumpForce = 10f;

    public float jumpPower = 15f;
    private Animator anim;
    Vector3 movement;
    private int direction = 1;
    bool isJumping = false;


    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

 
    private void Start()
    {
        _controller.OnMoveEvent += Move;
        //_controller.OnJumpEvent += Jump;    //����
    }

    //private void Update()   //����
    //{
    //    if (_isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
    //    {
    //        Jump();
    //    }
    //}



    void Jump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
        && !anim.GetBool("isJump"))
        {
            isJumping = true;
            anim.SetBool("isJump", true);
        }
        if (!isJumping)
        {
            return;
        }

        _rigidbody.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        _rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }





    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
    }


    private void OnCollisionEnter2D(Collision2D collision)  //����
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)   //����
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


    //private void Jump() //����
    //{
    //    if (_isGrounded)
    //    {
    //        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //    }
    //}

  

}
