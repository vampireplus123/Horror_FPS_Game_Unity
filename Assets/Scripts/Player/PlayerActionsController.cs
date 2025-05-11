using System;
using UnityEngine;
using UnityEngine.InputSystem;


public abstract class PlayerActionsController : MonoBehaviour,IPlayerConstructor
{
    [SerializeField]  float mouseSensitivity;

    [SerializeField]  float speed;

    [SerializeField] Transform PlayerBody;
    protected PlayerControls playerControls;
    protected Vector2 mouseLook;
    protected float xRotation = 0f;

    protected Vector2 moveInput;

    protected Rigidbody rb;


    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    public virtual void Look()
    {
        mouseLook = playerControls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * mouseX);

        Debug.Log("Mouse Delta X: " + mouseX);

    }

    public virtual void Movement()
    {
        Vector3 moveDirection = new Vector3(moveInput.x,0,moveInput.y);
        Vector3 velocity = moveDirection * speed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);  // Cập nhật vận tốc của Rigidbody.
    } 
}
