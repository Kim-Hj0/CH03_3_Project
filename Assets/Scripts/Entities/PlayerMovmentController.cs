using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerMovmentController : MonoBehaviour   //�̵� ���õ�
{
    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    //����
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();

        //����
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
        //����
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
    //    //�����̽�Ű�� ������ ����
    //    if (Input.GetKeyDown(KeyCode.Space)) 
    //    {
    //        //�ٴڿ� ������ ������ ����
    //        if (!IsJump)
    //        {
    //            IsJump = true;
    //            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    //        }

    //        //���߿� �������� ���� ���ϵ���.
    //        else 
    //        {
    //            return;
    //        }
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //�ٴڿ� ������
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
