using UnityEngine;
using UnityEngine.InputSystem;

public class AttackScript : MonoBehaviour
{
    public float attackRange = 6f;
    public int attackDamage = 5;
    public LayerMask enemyLayer;
    private bool attacking;
    private Animator animator;

    // Attack delay variables
    public float attackDelay = 1.5f;
    private float lastAttackTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackDamage = PlayerPrefs.GetInt("AttackDamage", 5);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        attacking = context.action.IsPressed();
        if (attacking == true)
        {
            Attack();
            animator.SetBool("IsHitting", true);
        }
        else
        {
            animator.SetBool("IsHitting", false);
        }
    }

    private void Attack()
    {
        // Check if enough time has elapsed since last attack
        if (Time.time - lastAttackTime > attackDelay) {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(attackDamage);
                }
            }

            // Update last attack time
            lastAttackTime = Time.time;
        }
    }

    public void UpgradeSword() 
    {
        attackDamage += 5;
        PlayerPrefs.SetInt("AttackDamage", attackDamage);
    }
}
