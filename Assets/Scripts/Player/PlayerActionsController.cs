using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerActionsController : MonoBehaviour, IPlayerConstructor
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] float speed;
    [SerializeField] Transform PlayerBody;
    [SerializeField] float gravity = -9.81f;


    private float velocityY = 0f;


    protected PlayerControls playerControls;
    protected Vector2 mouseLook;
    protected float xRotation = 0f;
    protected Vector2 moveInput;

    protected CharacterController characterController;

    private void Awake()
    {
        playerControls = new PlayerControls();
        characterController = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {
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
    }
    public virtual void Movement()
    {
        moveInput = playerControls.Player.Movement.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = PlayerBody.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Kiểm tra nếu đang đứng trên mặt đất thì reset tốc độ rơi
        if (characterController.isGrounded && velocityY < 0)
        {
            velocityY = -2f; // Đảm bảo dính sát mặt đất
        }

        // Áp lực hấp dẫn
        velocityY += gravity * Time.deltaTime;

        // Gộp cả hướng di chuyển và rơi
        moveDirection.y = velocityY;

        // Di chuyển
        characterController.Move(moveDirection * Time.deltaTime);
    }
    public int health()
    {
        return 100;
    }
}
