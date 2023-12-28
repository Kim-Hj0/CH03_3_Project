using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : PlayerAnimations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");


    //움직일 때, walk 애니메이션으로 전환
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
