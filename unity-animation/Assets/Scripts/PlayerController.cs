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

    public Transform cameraTransform;
    public float rotationSpeed = 10f;

    private Animator animator; // Add this
    private bool isMoving; // Track movement for animation

    void Start()
    {
        controller = GetComponent<CharacterController>();

        animator = GetComponentInChildren<Animator>(); // ✅ Fix

        if (animator == null)
        {
            Debug.LogError("Animator not found on Player or its children!");
        }

        startPosition = transform.position;

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
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


        if (isMoving)
        {
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0f; right.y = 0f;
            forward.Normalize(); right.Normalize();

            move = forward * inputDir.z + right * inputDir.x;
            controller.Move(move * moveSpeed * Time.deltaTime);

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
        isMoving = inputDir.magnitude >= 0.1f; //  Determine if moving
        animator.SetBool("isRunning", isMoving); //  Set Animator parameter
        Debug.Log("isRunning: " + isMoving);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump"); // Trigger jump animation
        }

        // Add this after isGrounded check
        bool fallingNow = !isGrounded && velocity.y < 0;
        animator.SetBool("isFalling", fallingNow);

    }


    void ResetToStart()
    {
        velocity = Vector3.zero;
        controller.enabled = false;
        transform.position = startPosition + Vector3.up * resetHeight;
        controller.enabled = true;
    }
}
