using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject interactUI;
    [SerializeField] private PlayerController playerOne;
    [SerializeField] private PlayerController PlayerTwo;
    bool interacted = false;
    bool opened = false;

    public void OnInteract(InputAction.CallbackContext context)
    {
        interacted = context.action.IsPressed();
        print("True");
    }

    public void OnCloseTap(InputAction.CallbackContext context)
    {
        if (opened == true) 
        {
            shopUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            opened = false;
            playerOne.enabled = true;
            PlayerTwo.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject.tag == "Shop")
        {
            interactUI.SetActive(true);
            if (interacted)
            {
                Shop();
            }
        }

        if (other.gameObject.tag == "Boss1")
        {
            interactUI.SetActive(true);
            if (interacted)
            {
                SceneManager.LoadScene(1);
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shop" || other.gameObject.tag == "Boss1")
        {
            print("interact");
            interactUI.SetActive(true);
        }
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shop" || other.gameObject.tag == "Boss1")
        {
            interactUI.SetActive(false);
        }
    }

    void Shop()
    {
        if (!opened)
        {
            playerOne.enabled = false;
            PlayerTwo.enabled = false;
            shopUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            opened = true;
            interactUI.SetActive(false);
        }
    }
}
