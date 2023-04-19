using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    
    
    [Header("Ladder")]
    public bool onLadder = false;
    public bool atLadder = false;
    [SerializeField] private BoxCollider boxCollider;
    
    [Header("MainUI")]
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject interactUI;

    [Header("ShopUI")]
    [SerializeField] private GameObject shopUI;
    [SerializeField] private PlayerController playerOne;
    [SerializeField] private PlayerController PlayerTwo;

    bool interacted = false;

    void Start()
    {   
        if (boxCollider == null)
        {
            boxCollider =  gameObject.GetComponent<BoxCollider>();
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        interacted = context.action.IsPressed();
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
                SceneManager.LoadScene(2);
            }
        }
        
        if (other.gameObject.tag == "ladder")
        {
            interactUI.SetActive(true);
            if (interacted) 
            {   
                boxCollider.enabled = false;
                onLadder = true;
                interactUI.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Shop" || other.gameObject.tag == "Boss1")
        {
            print("interact");
            interactUI.SetActive(true);
        }
        if (other.gameObject.tag == "ladder")
        {
            boxCollider.enabled = false;
            interactUI.SetActive(true);
            atLadder = true;
        }

        if (other.gameObject.tag == "Stick")
        {
            inventory.additem("Sticks", 1);
            inventory.sticks++;
            Destroy(other.gameObject);

        }
        
        if (other.gameObject.tag == "Gem")
        {
            inventory.additem("Gem", 1);
            inventory.gems++;
            Destroy(other.gameObject);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shop" || other.gameObject.tag == "Boss1")
        {
            interactUI.SetActive(false);
        }
        if (other.gameObject.tag == "ladder")
        {
            boxCollider.enabled = true;
            interactUI.SetActive(false);
            onLadder = false;
            atLadder = false;
        }
    }

    void Shop()
    {
        if (!shopUI.activeSelf)
        {
            playerOne.enabled = false;
            PlayerTwo.enabled = false;
            shopUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            interactUI.SetActive(false);
        }
    }
}
