using UnityEngine;

public class Playerhealth : MonoBehaviour
{
   public float health;

   void Start()
   {
     health = PlayerPrefs.GetFloat("Playerhealth", 20f)
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
}