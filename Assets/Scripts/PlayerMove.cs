using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Entrance entrance;
    Player player;
    PlayerControls playerControls;
    InputAction moveUp;
    InputAction moveDown;
    InputAction moveLeft;
    InputAction moveRight;

    Rigidbody2D rb2d;
    Vector2 currentPos;
    float moveSpeed = 10f;
    float stepSize = 1f;

    void Awake()
    {
        entrance = FindAnyObjectByType<Entrance>();
        player = GetComponent<Player>();
        playerControls = new PlayerControls();
        rb2d = GetComponent<Rigidbody2D>();

        moveUp = playerControls.Player.Up;
        moveDown = playerControls.Player.Down;
        moveLeft = playerControls.Player.Left;
        moveRight = playerControls.Player.Right;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            player.isAtExit = true;
            player.isAtEntrance = false;
        }
        if (other.gameObject.CompareTag("Start"))
        {
            player.isAtExit = false;
            player.isAtEntrance = true;
        }
    }

    void OnEnable()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable();

        moveUp.performed += MoveUp;
        moveDown.performed += MoveDown;
        moveLeft.performed += MoveLeft;
        moveRight.performed += MoveRight;
    }

    void OnDisable()
    {
        moveUp.Disable();
        moveDown.Disable();
        moveLeft.Disable();
        moveRight.Disable();

        moveUp.performed -= MoveUp;
        moveDown.performed -= MoveDown;
        moveLeft.performed -= MoveLeft;
        moveRight.performed -= MoveRight;
    }

    void Start()
    {
        currentPos = transform.position;
    }

    void Update()
    {
        if (!player.isAtExit)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPos, moveSpeed * Time.deltaTime);
        }

        if (player.isAtExit)
        {
            currentPos = entrance.transform.position;
            transform.position = entrance.transform.position;
        }
    }

    void MoveUp(InputAction.CallbackContext context) { 
        currentPos += new Vector2(0f, stepSize);
    }

    void MoveDown(InputAction.CallbackContext context) { 
        currentPos += new Vector2(0f, -stepSize);
    }

    void MoveLeft(InputAction.CallbackContext context) { 
        currentPos += new Vector2(-stepSize, 0f);
    }

    void MoveRight(InputAction.CallbackContext context) { 
        currentPos += new Vector2(stepSize, 0f);
    }

}