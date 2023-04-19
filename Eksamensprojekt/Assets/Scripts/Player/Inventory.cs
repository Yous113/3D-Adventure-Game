using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int sticks = 0;
    public int gems = 0;
    [SerializeField] private MainUI UI;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        sticks = PlayerPrefs.GetInt("SticksCount", 0);
        gems = PlayerPrefs.GetInt("GemsCount", 0);

        UI.UpdateInventory("Sticks", sticks);
        UI.UpdateInventory("Gems", gems);
    }

    public void additem(string itemName, int amount)
    {
        UI.UpdateInventory(itemName, amount);
        PlayerPrefs.SetInt("SticksCount", sticks);
        PlayerPrefs.SetInt("GemsCount", gems);
    }
}
