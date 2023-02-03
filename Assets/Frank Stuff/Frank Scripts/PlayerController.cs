using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform playerCamera = null;
    [SerializeField]
    float mouseSensitivityX = 3.5f, mouseSensitivityY = 3.5f, gravity = -13.0f, movementSpeed = 6.0f, sprintMultiplier = 1.5f, stamina = 10;
    [SerializeField]
    [Range(0.0f, 0.5f)]
    float moveSmoothTime = 0.3f;

    [SerializeField]
    KeyCode interact, sprint, inv1, inv2, inv3, dropItem;

    [SerializeField]
    bool lockCursor = true, sprinting = false;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;

    CharacterController controller = null;

    public int currentAnimationFrame;

    public int[] itemInventory = new int[3];
    public int selectedItem = 0;

    [SerializeField]
    GameObject interactIndicator;

    public GameObject[] itemList;

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

        cameraPitch = Mathf.Clamp(cameraPitch, -80.0f, 80.0f);

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
        else
        {
            velocityY += gravity * Time.deltaTime;
        }
        

        if (Input.GetKey(sprint) && stamina > 0)
        {
            sprinting = true;
            stamina -= Time.deltaTime;
        }
        else
        {
            sprinting = false;
        }

        Vector3 velocity;
        if (sprinting)
        {
            velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * movementSpeed * sprintMultiplier + Vector3.up * velocityY;
        }
        else
        {
            velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * movementSpeed + Vector3.up * velocityY;
        }
        
        if (velocity == new Vector3(0, velocity.y, 0) && stamina < 10)
        {
            stamina += Time.deltaTime * 2;
        }
        else if(stamina > 10)
        {
            stamina = 10;
        }
        

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(inv1))
        {
            selectedItem = 0;
        }

        if (Input.GetKeyDown(inv2))
        {
            selectedItem = 1;
        }

        if (Input.GetKeyDown(inv3))
        {
            selectedItem = 2;
        }

        if (Input.GetKeyDown(dropItem))
        {
            if (itemInventory[selectedItem] != 0)
            {
                print(itemInventory[selectedItem]);
                GameObject thing = Instantiate(itemList[itemInventory[selectedItem]-1], transform.position + transform.forward, Quaternion.identity);
                thing.name = itemList[itemInventory[selectedItem] - 1].name;
                itemInventory[selectedItem] = 0;
            }
        }
    }

    void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 3f))
        {
            
            
            if (hit.transform.tag == "Interactable")
            {
                DefaultInteractable target = hit.transform.GetComponent<DefaultInteractable>();
                target.player = gameObject;
                target.OnInteract();
                
            }
            else
            {
                print("Wall Hit");
                Instantiate(interactIndicator, hit.point, Quaternion.identity);
            }
        }
    }

    
}
