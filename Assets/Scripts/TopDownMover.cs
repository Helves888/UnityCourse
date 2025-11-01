using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMover : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _speedX = 1f;
    [SerializeField] private float _speedDash = 3f;
    [SerializeField] private float _dashCooldown = 1f;

    private float _horizontalDirection;
    private float _verticalDirection;
    private bool _isDashing = false;
    private float _dashTime = 0f;
    private float _dashCooldownTimer = 0f;
   

    private void Update()
    {
        _horizontalDirection = Input.GetAxis(HorizontalAxis);
        _verticalDirection = Input.GetAxis(VerticalAxis);
        Vector3 moveDirection = new Vector3(_horizontalDirection, _verticalDirection, 0f).normalized;
        HandleDashInput();

        if (_isDashing)
        {
            transform.position += moveDirection * _speedX * _speedDash * Time.deltaTime;
            _dashTime -= Time.deltaTime;
           
            if (_dashTime <= 0f)
            {
                _isDashing = false;
                _dashCooldownTimer = _dashCooldown;
            }
        }
        else
        {
            transform.position += (Vector3)(moveDirection * _speedX * Time.deltaTime);
        }

        if (_dashCooldownTimer > 0f)
            _dashCooldownTimer -= Time.deltaTime;
    }

    private void HandleDashInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (_horizontalDirection != 0 || _verticalDirection != 0) &&
        _dashCooldownTimer <= 0f)
        {
            _isDashing = true;
            _dashTime = 0.2f;
        }
    }

    

}
