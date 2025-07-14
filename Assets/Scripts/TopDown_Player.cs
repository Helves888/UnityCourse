using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_Player : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    [SerializeField] private float _speedX = 1f;
    [SerializeField] private float _speedDash = 3f;

    private float _horizontal_direction;
    private float _vertical_direction;
    private bool _isDashing = false;
    private float _dashTime = 0f;

    private void DashInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ((_horizontal_direction != 0 || _vertical_direction != 0)))
        {
            _isDashing = true;
            _dashTime = 0.2f;
        }
    }

    private void Update()
    {
        _horizontal_direction = Input.GetAxis(HORIZONTAL_AXIS);
        _vertical_direction = Input.GetAxis(VERTICAL_AXIS);

        Vector2 moveDirection = new Vector2(_horizontal_direction, _vertical_direction).normalized;
        DashInput();
        if (_isDashing)
        {
            transform.position += (Vector3)(moveDirection * _speedX * _speedDash * Time.deltaTime);
            _dashTime -= Time.deltaTime;
            if (_dashTime <= 0f)
            {
                _isDashing = false;
            }
        }
        else
        {

            transform.position += (Vector3)(moveDirection * _speedX * Time.deltaTime);

        }
    }

}
