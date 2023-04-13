using UnityEngine;
using UnityEngine.InputSystem;

public class Defend : MonoBehaviour
{
    private CharacterController controller;
    public bool shieldactive = false;
    private bool defending;
    [SerializeField]
    private PlayerController movementScript;

    public void OnDefend(InputAction.CallbackContext context)
    {
        defending = context.action.IsPressed();
        if (defending == true && shieldactive == false)
        {
            shieldactive = true;
            movementScript.playerSpeed = movementScript.playerSpeed/2;
            Debug.Log("Defend button pressed");
        } else if (defending == false)
        {
            movementScript.playerSpeed = movementScript.playerSpeed * 2;
            shieldactive = false;
            Debug.Log("Defend button released");
        }
    }

    /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            shieldactive = true;
            Debug.Log("Defend button pressed");
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            shieldactive = false;
            Debug.Log("Defend button released");
        }
    } */
}
