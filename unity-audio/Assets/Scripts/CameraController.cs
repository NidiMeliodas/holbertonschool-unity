using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Reference to the player
    public Vector3 offset = new Vector3(0, 2.5f, -6.25f); // Camera offset
    public float mouseSensitivity = 100f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor for FPS-style control
    }

    void Update()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical camera rotation (pitch)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 60f);

        // Horizontal camera rotation (yaw)
        yRotation += mouseX;

        // Apply rotation to camera only
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    void LateUpdate()
    {
        // Camera follows player’s position + rotation applied above
        transform.position = target.position + transform.rotation * offset;
    }
}
