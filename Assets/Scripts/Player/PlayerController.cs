using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnJumpEvent;    //����
    public event Action OnSlideEvent;   //�����̵�

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallJumpEvent()
    { 
        OnJumpEvent?.Invoke();
    }

    public void CallSlideEvent()
    {
        OnSlideEvent?.Invoke();
    }

    

}
