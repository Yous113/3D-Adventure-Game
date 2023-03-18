using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[3, 3];
    [SerializeField] private Inventory inventory;
    public TMP_Text stickText;
    
    // Start is called before the first frame update
    void Start()
    {
        stickText.text = "Sticks:" + inventory.sticks.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        // Sticks
        shopItems[2, 1] = 1;
        shopItems[2, 2] = 2;
        shopItems[2, 3] = 3;

        // Gems
        shopItems[3, 1] = 1;
        shopItems[3, 2] = 2;
        shopItems[3, 3] = 3;


    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (inventory.sticks >= shopItems[2, ButtonRef.GetComponent<ShopButtonsInfo>().itemID])
        {
            inventory.sticks -= shopItems[2, ButtonRef.GetComponent<ShopButtonsInfo>().itemID];
        }
    }
}
