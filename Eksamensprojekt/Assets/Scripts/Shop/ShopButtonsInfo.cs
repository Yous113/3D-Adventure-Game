using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonsInfo : MonoBehaviour
{
    public int itemID;
    public TMP_Text sticksNeeded;
    public TMP_Text gemsNeeded;
    public GameObject ShopManager;
    
    // Start is called before the first frame update
    void Update()
    {
        sticksNeeded.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[2, itemID].ToString();
        gemsNeeded.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, itemID].ToString();
    }
}
