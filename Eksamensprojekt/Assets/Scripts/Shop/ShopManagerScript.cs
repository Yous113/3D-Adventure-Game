using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ShopManagerScript : MonoBehaviour
{
    
    [Header("UI")]
    public TMP_Text stickText;
    public TMP_Text gemText;
    public GameObject player1;
    public GameObject player2;
    public GameObject shopUI;
    [SerializeField] private HealthBarScript healthBar1;
    [SerializeField] private HealthBarScript healthBar2;

    [Header("Scripts")]
    [SerializeField] private Inventory inventory;
    [SerializeField] private PlayerController playerOne;
    [SerializeField] private PlayerController playerTwo;

    public bool opened;
    // Start is called before the first frame update
    void Start()
    {
        shopUI.SetActive(false);
        UpdateUI();
        PlayerOneShop();
    }

    public void OnCloseTap(InputAction.CallbackContext context)
    {
        if (shopUI.activeSelf)
        {
            shopUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            opened = false;
            playerOne.enabled = true;
            playerTwo.enabled = true;

        }
    }

    public void UpdateUI()
    {
        stickText.text = inventory.sticks.ToString();
        gemText.text = inventory.gems.ToString();
        healthBar1.UpdateHealthbar();
        healthBar2.UpdateHealthbar();
    }

    public void PlayerOneShop()
    {
        player1.SetActive(true);
        player2.SetActive(false);
    }
    public void PlayerTwoShop()
    {
        player1.SetActive(false);
        player2.SetActive(true);
    }
}
