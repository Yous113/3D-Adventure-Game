using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.82f; 

    private Animator animator;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;
    
    //ladder
    [SerializeField] private Interaction interactionScript;
    private bool climbing;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        interactionScript = gameObject.GetComponent<Interaction>();
    }

    public void OnMove(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) {
        jumped = context.action.triggered;
    }

    public void OnClimbing(InputAction.CallbackContext context) {
        if(!climbing) {
            climbing = context.action.triggered;
        } 
        else 
        {
            climbing = false;
        }
    }


    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            animator.SetBool("IsJumping", false);
        }

        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
        move.z = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            animator.SetBool("IsWalking", true);
            gameObject.transform.eulerAngles = new Vector3(0, movementInput.x > 0 ? 0 : 180, 0);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        
        if (jumped && groundedPlayer && !interactionScript.atLadder)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetBool("IsJumping", true);
        }

        if (interactionScript.onLadder)
        {
            LadderBehaviour();
        }

        if (!interactionScript.onLadder)
        {
            new Vector3(0, 0, 0);
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void LadderBehaviour()
    {
        gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
        if (climbing == true)
        {
            playerVelocity.y += 0.04f * Time.deltaTime;
        }
    }
}

