using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[4, 4];
    [SerializeField] private Inventory inventory;
    public TMP_Text stickText;
    public TMP_Text gemText;
    
    // Start is called before the first frame update
    void Start()
    {
        stickText.text = "Sticks: " + inventory.sticks.ToString();
        gemText.text = "gems :" + inventory.gems.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        // Sticks
        shopItems[2, 1] = 7;
        shopItems[2, 2] = 10;
        shopItems[2, 3] = 20;

        // Gems
        shopItems[3, 1] = 2;
        shopItems[3, 2] = 4;
        shopItems[3, 3] = 10;


    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (inventory.sticks >= shopItems[2, ButtonRef.GetComponent<ShopButtonsInfo>().itemID])
        {
            inventory.sticks -= shopItems[2, ButtonRef.GetComponent<ShopButtonsInfo>().itemID];
            inventory.gems -= shopItems[3, ButtonRef.GetComponent<ShopButtonsInfo>().itemID];
            stickText.text = "Sticks: " + inventory.sticks.ToString();
            gemText.text = "gems: " + inventory.gems.ToString();
        }
    }
}
