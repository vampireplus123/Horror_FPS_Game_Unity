using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private Vector2 moveInput;

    private PlayerControls playerControls;
    private Rigidbody rb;

    void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }
    void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        moveInput = playerControls.Player.Movement.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        Vector3 moveDirection = new Vector3(moveInput.x,0,moveInput.y);
        Vector3 velocity = moveDirection * speed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);  // Cập nhật vận tốc của Rigidbody.
    }
}
