using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform playerCamera = null;
    [SerializeField]
    float mouseSensitivityX = 3.5f, mouseSensitivityY = 3.5f, gravity = -13.0f, movementSpeed = 6.0f;
    [SerializeField]
    [Range(0.0f, 0.5f)]
    float moveSmoothTime = 0.3f;

    [SerializeField]
    KeyCode interact;

    [SerializeField]
    bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;

    CharacterController controller = null;

    [SerializeField]
    GameObject interactIndicator;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouse();
        UpdateMovement();
        if (Input.GetKeyDown(interact))
        {
            Interact();
        }
    }

    void UpdateMouse()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDelta.y * mouseSensitivityY; //we have to subtrackt, otherwise looking down will turn the camera up

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivityX);

    }

    void UpdateMovement()
    {

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
        }
        velocityY += gravity * Time.deltaTime;


        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * movementSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

    }

    void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 1.5f))
        {
            print("Interacted");
            Instantiate(interactIndicator, hit.point, Quaternion.identity);
        }
    }
}
