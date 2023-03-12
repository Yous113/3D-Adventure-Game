using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float attackRange = 10f;
    public int attackDamage = 5;
    public LayerMask enemyLayer;
    [SerializeField] private AudioSource slash;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Attack();
            slash.Play();
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
            }
        }
    }
}