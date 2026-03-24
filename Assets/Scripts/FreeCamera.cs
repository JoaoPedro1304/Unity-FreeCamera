using UnityEngine;

using UnityEngine.InputSystem;

public class FreeCamera : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    public float fastSpeed = 25f;
    public float mouseSensitivity = 0.2f;

    private float currentSpeed;
    private Vector2 lookInput;
    private Vector2 moveInput;
    private float verticalInput;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private CameraActions inputActions;

    private void Awake()
    {
        inputActions = new CameraActions();

        inputActions.Camera.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Camera.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Camera.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        inputActions.Camera.Look.canceled += ctx => lookInput = Vector2.zero;

        inputActions.Camera.Up.performed += ctx => verticalInput = 1f;
        inputActions.Camera.Up.canceled += ctx => verticalInput = 0f;

        inputActions.Camera.Down.performed += ctx => verticalInput = -1f;
        inputActions.Camera.Down.canceled += ctx => verticalInput = 0f;

        inputActions.Camera.Fast.performed += ctx => currentSpeed = fastSpeed;
        inputActions.Camera.Fast.canceled += ctx => currentSpeed = moveSpeed;
    }

    private void OnEnable()
    {
        inputActions.Enable();
        currentSpeed = moveSpeed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    private void HandleMouseLook()
    {
        rotationX += lookInput.x * mouseSensitivity;
        rotationY -= lookInput.y * mouseSensitivity;

        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }

    private void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        move += transform.up * verticalInput;

        transform.position += move * currentSpeed * Time.deltaTime;
    }
}