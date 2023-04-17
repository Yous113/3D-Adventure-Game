using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int sticks;
    public int gems = 0;
    [SerializeField] private MainUI UI;

    void Start()
    {
        sticks = PlayerPrefs.GetInt("SticksCount", 0);
        gems = PlayerPrefs.GetInt("GemsCount", 0);

        UI.UpdateInventory("Sticks", sticks);
        UI.UpdateInventory("Gems", gems);
    }

    public void additem(string itemName, int item)
    {
        item++;
        UI.UpdateInventory(itemName, item);

        if (itemName == "Sticks")
        {
            PlayerPrefs.SetInt("SticksCount", item);
        }
        else if (itemName == "Gems")
        {
            PlayerPrefs.SetInt("GemsCount", item);
        }
    }
}
