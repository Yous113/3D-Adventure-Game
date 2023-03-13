using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Inventory inventory;
    bool interacted;
    
    public void OnInteract(InputAction.CallbackContext context)
    {
        interacted = context.action.triggered;  
    }
    
    private void OnTriggerStay(Collider other) {
        if (interacted && other.gameObject.tag == "Shop")
        {
            shopUI.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stick")
        {
            inventory.additem(inventory.sticks);
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "Gem")
        {
            inventory.additem(inventory.gem);
            Destroy(other.gameObject);
        }
        
    }
}
