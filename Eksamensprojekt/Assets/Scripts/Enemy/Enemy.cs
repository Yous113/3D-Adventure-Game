using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float health = 10f;

   public GameObject[] loot;
    public bool dead = false;

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
        dead = true;
        Instantiate(loot[Random.Range(0,2)], transform.position, Quaternion.identity);
   }
}