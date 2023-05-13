using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystem : MonoBehaviour
{
    public event Action OnLeftMouseClick;
    public event Action OnSpacePressed;
    public event Action OnKeyEPressed;

    public bool isMoving { get; set; } = true;

    public Vector3 GetDirectionMove()
    {
        if (isMoving == false)
            return Vector3.zero;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        return direction;
    }

    public Vector3 GetDirectionMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector2 direction = new Vector2(mouseX, mouseY);
        return direction;
    }

    private void Update()
    {
        if (isMoving == false)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            OnLeftMouseClick?.Invoke();
        }
    }
}

