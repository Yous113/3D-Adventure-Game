using UnityEngine;
using UnityEngine.InputSystem;

public class Defend : MonoBehaviour
{
    private CharacterController controller;
    public bool shieldactive = false;
    private bool defending;
    [SerializeField]
    private PlayerController movementScript;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDefend(InputAction.CallbackContext context)
    {
        defending = context.action.IsPressed();
        if (defending == true && shieldactive == false)
        {
            shieldactive = true;
            animator.SetBool("IsDefending", true);
            movementScript.playerSpeed = movementScript.playerSpeed/2;
            Debug.Log("Defend button pressed");
        } 
        
        else if (defending == false)
        {
            movementScript.playerSpeed = movementScript.playerSpeed * 2;
            shieldactive = false;
            animator.SetBool("IsDefending", false);
            Debug.Log("Defend button released");
        }
    }
}
