using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    public TMP_Text inventoryText;

    private void Start() 
    {
        inventoryText.enabled = false;
    }

    public void UpdateInventory(string itemText, int amount) {
        inventoryText.text = itemText + ' ' + amount + 'x';
        StartCoroutine(WaitBeforeClosing());
    }

    private IEnumerator WaitBeforeClosing()
    {
        inventoryText.enabled = true;
        yield return new WaitForSeconds(1);
        inventoryText.enabled = false;
    }
}
