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

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
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

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Fall reset check
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
