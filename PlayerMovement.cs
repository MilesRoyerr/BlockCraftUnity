using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   // Speed of player movement
    public float jumpForce = 5f;   // Jump force
    public float lookSpeed = 2f;   // Mouse look speed
    public Transform playerCamera; // Reference to the camera attached to the player

    private Rigidbody rb;
    private float cameraPitch = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the mouse cursor
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
        HandleJumping();
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f); // Clamp up/down look

        playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); // Rotate player on the Y-axis
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }

    void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f); // Raycast to check if grounded
    }
}
