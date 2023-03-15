using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int sticks = 0;
    public int gem = 0;
    [SerializeField] private MainUI UI;

    public void additem(string itemName, int item){
        item++;
        print(item);
        UI.UpdateInventory(itemName, item);
    }
}
