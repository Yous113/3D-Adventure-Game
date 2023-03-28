using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
   public float health = 20f;

   public void TakeDamage (float amount)
   {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
   }
   void Die()
   {
        Destroy(gameObject);
   }
}