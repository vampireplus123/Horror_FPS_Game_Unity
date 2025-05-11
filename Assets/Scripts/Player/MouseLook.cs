using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private PlayerControls PlayerControls;
    public float mouseSensitivity = 0;

    private Vector2 mouseLook;
    private float xRotation = 0f;

    public Transform PlayerBody;
    void Awake()
    {
        PlayerControls = new PlayerControls();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnEnable()
    {
        PlayerControls.Enable();
    }
    void Update()
    {
        Look();
    }

    void OnDisable()
    {
        PlayerControls.Disable();
    }
    void Look()
    {
        mouseLook = PlayerControls.Player.Look.ReadValue<Vector2>();
        float mouseX = mouseLook.x * mouseSensitivity*Time.fixedDeltaTime;
        float mouseY = mouseLook.y * mouseSensitivity* Time.fixedDeltaTime;
        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation,-90f,90f);

        transform.localRotation  = Quaternion.Euler(xRotation,0,0);
        PlayerBody.Rotate(Vector3.up*mouseX);
    }
}
