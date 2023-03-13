using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int sticks = 0;
    public int gem = 0;

    public void additem(int item){
        item++;
        print(item);
    }
}
