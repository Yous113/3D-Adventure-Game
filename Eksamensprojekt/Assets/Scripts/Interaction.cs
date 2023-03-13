using UnityEngine;
using UnityEngine.InputSystem;
public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Inventory inventory;
    bool interacted = false;
    bool opened = false;
    
    public void OnInteract(InputAction.CallbackContext context)
    {
        interacted = context.action.IsPressed();

        //if (!context.action.IsPressed())
        //{
          //  interacted = false;
        //}
        //else
        //{
         //   interacted = true;
        //}
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
            inventory.additem(inventory.sticks);
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "Gem")
        {
            inventory.additem(inventory.gem);
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
        else
        {
            shopUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            opened = false;
        }
    }
}
