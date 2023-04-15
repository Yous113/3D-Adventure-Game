using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public TMP_Text stickText;
    public TMP_Text gemText;
    public GameObject playerOne;
    public GameObject playerTwo;

    // Start is called before the first frame update
    void Start()
    {
        stickText.text = "Sticks: " + inventory.sticks.ToString();
        gemText.text = "gems :" + inventory.gems.ToString();
        PlayerOneShop();
    }

    // Update is called once per frame
    public void Buy(int sticks, int gems)
    {

        if (inventory.sticks >= sticks || inventory.gems >= gems)
        {
            inventory.sticks -= gems;
            inventory.gems -= gems;
            stickText.text = "Sticks: " + inventory.sticks.ToString();
            gemText.text = "gems: " + inventory.gems.ToString();
        }
    }

    public void PlayerOneShop()
    {
        playerOne.SetActive(true);
        playerTwo.SetActive(false);
    }
    public void PlayerTwoShop()
    {
        playerOne.SetActive(false);
        playerTwo.SetActive(true);
    }
}
