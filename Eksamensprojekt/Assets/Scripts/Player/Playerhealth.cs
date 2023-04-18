using UnityEngine;
using TMPro;

public class Playerhealth : MonoBehaviour
{
    
    [Header("Health")]
    public float health;

    // Healing
    [Header("Healing")]
    private int gemsneeded = 2;
    [SerializeField] private TMP_Text gemsneededText;
    [SerializeField] Inventory inventory;
    [SerializeField] ShopManagerScript shopUI;



    void Start()
    {
        health = PlayerPrefs.GetFloat("Playerhealth", 20f);
        gemsneededText.text = gemsneeded.ToString();
    }
   
    public void TakeDamage (float amount)
   {
     health -= amount;
     if (health <= 0f)
     {
       Die();
     }
     PlayerPrefs.SetFloat("PlayerHealth", health);

   }
    void Die()
   {
        Destroy(gameObject);
   }
    public void HealthPotion()
    {
        if (inventory.gems > gemsneeded)
        {
            health = 20f;
            PlayerPrefs.SetFloat("Playerhealth", health);
            inventory.gems -= gemsneeded;
            shopUI.UpdateUI();
            gemsneededText.text = gemsneeded.ToString();
        }
    }

}