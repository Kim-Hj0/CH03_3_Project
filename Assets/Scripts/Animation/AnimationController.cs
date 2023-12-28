using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : PlayerAnimations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");


    //������ ��, walk �ִϸ��̼����� ��ȯ
    PlayerInputController controller;

    [SerializeField] private Animator anim;
    private void Awake()
    {
        base.Awake();
        controller = GetComponent<PlayerInputController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller.OnMoveEvent += Move;
    }


    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > .5f);
    }

}
