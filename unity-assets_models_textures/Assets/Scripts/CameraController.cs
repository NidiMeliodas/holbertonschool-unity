using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Reference to the player
    public Vector3 offset = new Vector3(0, 5, -7); // Default offset behind the player
    public float rotationSpeed = 5f;
    public bool requireRightClick = false;

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraController: No target set.");
            return;
        }

        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        bool rotating = !requireRightClick || Input.GetMouseButton(1);

        if (rotating)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            yaw += mouseX * rotationSpeed;
            pitch += mouseY * rotationSpeed;
            pitch = Mathf.Clamp(pitch, -35f, 60f);
        }

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
