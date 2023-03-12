// using UnityEngine;
// using UnityEngine.InputSystem;

// public class Defend : MonoBehaviour
// {
//     private CharacterController controller;
//     private bool shieldactive = false;

//     public void OnDefend(InputAction.CallbackContext context) 
//     {
//         if (context.performed)
//         {
//             shieldactive = true;
//             Debug.Log("Defend button pressed");
//         }
//         else if (context.canceled)
//         {
//             shieldactive = false;
//             Debug.Log("Defend button released");
//         }
//     }
// }