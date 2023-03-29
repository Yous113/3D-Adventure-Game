using UnityEngine;
using UnityEngine.InputSystem;

public class AttackScript : MonoBehaviour
{
    public float attackRange = 10f;
    public int attackDamage = 5;
    public LayerMask enemyLayer;
    [SerializeField] private AudioSource slash;
    private bool attacking;

    public void OnAttack(InputAction.CallbackContext context)
    {
        attacking = context.action.IsPressed();
        if (attacking == true)
        {
            print("attack");
            Attack();
            slash.Play();
        }
    }
    private void Update()
    {
        
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