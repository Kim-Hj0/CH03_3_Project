using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerMovmentController : MonoBehaviour   //이동 관련된
{
    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    //점프
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();

        //점프
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

 
    private void Start()
    {
        _controller.OnMoveEvent += Move;       
        //_controller.OnJumpEvent += Jump;
    }

    private void Update()
    {
        //점프
        if (Input.GetKeyDown(KeyCode.Space))
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            anim.SetBool("IsJumping", true);

        //Stop Speed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f,rigid.velocity.y);
        }
    }

    //private void Jump()
    //{
    //    //스페이스키를 누르면 점프
    //    if (Input.GetKeyDown(KeyCode.Space)) 
    //    {
    //        //바닥에 있으면 점프를 실행
    //        if (!IsJump)
    //        {
    //            IsJump = true;
    //            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    //        }

    //        //공중에 떠있으면 점프 못하도록.
    //        else 
    //        {
    //            return;
    //        }
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //바닥에 닿으면
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        IsJump = false;
    //    }
    //}

    
    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
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
}
