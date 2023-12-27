using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour   //이동 관련된
{
    //그라운드 하지 않을 때는, 점프가 되긴 했음. 계속 위로만 올라갈 뿐.
    //땅에 닿았을 때만 점프할 수 있게 하긴 했지만, 아직 땅이 없어서 확인 불가.

    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;


    //private bool _isJumping = false; // 추가된 변수: 점프 상태를 나타내는 플래그
    //private bool _isGrounded = false;
    //private float _jumpForce = 10f; // 추가된 변수: 점프에 사용될 힘

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
    //    // 플레이어의 착지 여부를 확인 (Collider가 Ground 레이어와 충돌하는지 여부로 확인)//나중에 배경만들면 연결.
    //    _isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));

    //    if (_isGrounded)
    //    {
    //        // 플레이어가 착지 상태이면 점프를 허용합니다.
    //        _isJumping = false;
    //    }
    //}

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);

        //// 점프
        //if (_isJumping && _isGrounded)
        //{
        //    _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        //    _isJumping = false; // 점프 상태 초기화
        //}
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    //private void Jump()
    //{
    //    if (_isGrounded)    // 착지 상태에서만 점프 허용.
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
