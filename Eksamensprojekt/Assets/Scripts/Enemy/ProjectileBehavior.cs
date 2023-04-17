using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private int damage;

    public void SetDamage(int value)
    {
        damage = value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Playerhealth health = collision.gameObject.GetComponent<Playerhealth>();
            Defend defend = collision.gameObject.GetComponent<Defend>();
            if (health != null && (defend == null || !defend.shieldactive))
            {
                health.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
