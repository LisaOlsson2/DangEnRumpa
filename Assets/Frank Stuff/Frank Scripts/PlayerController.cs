using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform playerCamera = null;
    [SerializeField]
    float mouseSensitivityX = 3.5f, mouseSensitivityY = 3.5f, gravity = -13.0f, movementSpeed = 6.0f, sprintMultiplier = 1.5f;
    public float stamina = 10, health = 100;
    [SerializeField]
    [Range(0.0f, 0.5f)]
    float moveSmoothTime = 0.3f;

    [SerializeField]
    KeyCode interact, sprint, inv1, inv2, inv3, dropItem, dropTool, exit, heal, selfDamage;

    [SerializeField]
    bool lockCursor = true, sprinting = false, spectating = false;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;

    CharacterController controller = null;

    public int currentAnimationFrame;

    public int[] itemInventory = new int[3];
    public int selectedItem = 0;

    [SerializeField]
    GameObject interactIndicator;

    public int tool;


    public GameObject[] itemList, toolList;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<PhotonView>().IsMine)
        {
            PhotonNetwork.Destroy(transform.GetChild(0).gameObject);
            this.enabled = false;
        }
        else
        {

            PhotonNetwork.Destroy(transform.GetChild(1).gameObject);
        }

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
        if (transform.childCount > 1 && transform.GetChild(1) != null)
        {
            GameObject shape = transform.GetChild(1).gameObject;
            if (spectating)
            {
                shape.GetComponent<SpriteRenderer>().color = Color.clear;
            }
            else
            {
                shape.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        
        if (spectating)
        {
            stamina = 10;
            Camera.main.fieldOfView = 90;
            
            
        }
        else
        {
            if (Input.GetKeyDown(interact) && !spectating)
            {
                Interact();
            }
            Camera.main.fieldOfView = 60;
            
        }

        if (Input.GetKeyDown(exit))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
        if (Input.GetKeyDown(heal))
        {
            health = 100;
            spectating = false;
        }

        if (Input.GetKeyDown(selfDamage))
        {
            TakeDamage(50);
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
        
        if (targetDir == new Vector2(0, 0) && stamina < 10)
        {
            stamina += Time.deltaTime * 0.6f;
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
                GameObject thing = PhotonNetwork.Instantiate(itemList[itemInventory[selectedItem]-1].name, transform.position + transform.forward * 1.5f, Quaternion.identity);
                thing.name = itemList[itemInventory[selectedItem] - 1].name;
                itemInventory[selectedItem] = 0;
            }
        }
        if (Input.GetKeyDown(dropTool))
        {
            if (tool != 0)
            {
                
                GameObject thing = PhotonNetwork.Instantiate(toolList[tool-1].name, transform.position + transform.forward * 1.5f, Quaternion.identity);
                thing.name = toolList[tool - 1].name;
                tool = 0;
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
                //Debug.LogError("interacted");
            }
            else if (hit.transform.tag == "player")
            {
                PlayerController target = hit.transform.GetComponent<PlayerController>();
                target.TakeDamage(100);
            }
            else
            {
                print("Wall Hit");
                Instantiate(interactIndicator, hit.point, Quaternion.identity);
                //Debug.LogError("miss");
            }
        }
    }

    public void TakeDamage(float dmgAmmount)
    {
        health -= dmgAmmount;

        if (health <= 0)
        {
            spectating = true;
        }
    }

    
}
