using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 startPosition;
    public float fallThreshold = -20f;
    public float resetHeight = 10f;

    public Transform cameraTransform; // ✅ Add this to get camera-relative movement
    public float rotationSpeed = 10f; // For smooth rotation

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Auto-assign if not set
        }
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(moveX, 0f, moveZ).normalized;

        Vector3 move = Vector3.zero;

        if (inputDir.magnitude >= 0.1f)
        {
            // ✅ Move relative to camera
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0f; right.y = 0f;
            forward.Normalize(); right.Normalize();

            move = forward * inputDir.z + right * inputDir.x;
            controller.Move(move * moveSpeed * Time.deltaTime);

            // ✅ Smoothly rotate to face move direction
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < fallThreshold)
        {
            ResetToStart();
        }
    }

    void ResetToStart()
    {
        velocity = Vector3.zero;
        controller.enabled = false;
        transform.position = startPosition + Vector3.up * resetHeight;
        controller.enabled = true;
    }
}
