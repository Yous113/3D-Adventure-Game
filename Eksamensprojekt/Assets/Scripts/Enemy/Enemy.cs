using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float health = 10f;

   public GameObject[] loot;


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
        Instantiate(loot[Random.Range(0,2)], transform.position, Quaternion.identity);
   }
}