using UnityEngine;
using UnityEngine.InputSystem;
public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Inventory inventory;
    bool interacted = false;
    bool opened = false;
    bool inShop = false;
    
    public void OnInteract(InputAction.CallbackContext context)
    {
        interacted = context.action.IsPressed();
    }

    public void OnCloseTap(InputAction.CallbackContext context)
    {
        if (opened = true) 
        {
            shopUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            opened = false;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (interacted && other.gameObject.tag == "Shop")
        {
            Shop();
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stick")
        {
            inventory.additem("Sticks", inventory.sticks);
            Destroy(other.gameObject);

        }
        
        if (other.gameObject.tag == "Gem")
        {
            inventory.additem("Gem", inventory.gems);
            Destroy(other.gameObject);
        }
        
    }

    void Shop()
    {
        if (!opened)
        {
            shopUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            opened = true;
        }
    }
}
