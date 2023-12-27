using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour   //�̵� ���õ�
{
    //�׶��� ���� ���� ����, ������ �Ǳ� ����. ��� ���θ� �ö� ��.
    //���� ����� ���� ������ �� �ְ� �ϱ� ������, ���� ���� ��� Ȯ�� �Ұ�.

    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;


    //private bool _isJumping = false; // �߰��� ����: ���� ���¸� ��Ÿ���� �÷���
    //private bool _isGrounded = false;
    //private float _jumpForce = 10f; // �߰��� ����: ������ ���� ��

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

  

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        //_controller.OnJumpEvent += Jump;
    }

    //private void Update()
    //{
    //    // �÷��̾��� ���� ���θ� Ȯ�� (Collider�� Ground ���̾�� �浹�ϴ��� ���η� Ȯ��)//���߿� ��游��� ����.
    //    _isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));

    //    if (_isGrounded)
    //    {
    //        // �÷��̾ ���� �����̸� ������ ����մϴ�.
    //        _isJumping = false;
    //    }
    //}

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);

        //// ����
        //if (_isJumping && _isGrounded)
        //{
        //    _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        //    _isJumping = false; // ���� ���� �ʱ�ȭ
        //}
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    //private void Jump()
    //{
    //    if (_isGrounded)    // ���� ���¿����� ���� ���.
    //    {
    //        _isJumping = true;
    //    }
    //}

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * 5;
        _rigidbody.velocity = direction;
    }
}
