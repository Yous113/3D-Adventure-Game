using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class AttackScript : MonoBehaviour
{
    [Header("AttackVariables")]
    public float attackRange = 6f;
    public int attackDamage = 5;
    public float attackDelay = 1.5f;
    private float lastAttackTime;
    public LayerMask enemyLayer;
    private bool attacking;

    private Animator animator;
    
    [Header("Upgrade/Crafting")]
    private int sticksneeded;
    private int gemsneeded;
    [SerializeField] private TMP_Text sticksneededText;
    [SerializeField] private TMP_Text gemsneededText;
    [SerializeField] Inventory inventory;
    [SerializeField] ShopManagerScript shopUI;
    
    [SerializeField] private AudioSource nothit;
    [SerializeField] private AudioSource hit;



    private void Start()
    {
        PlayerPrefs.DeleteAll();
        animator = GetComponent<Animator>();
        attackDamage = PlayerPrefs.GetInt("AttackDamage", 5);
        sticksneeded = PlayerPrefs.GetInt("Sticksneeded", 5);
        gemsneeded = PlayerPrefs.GetInt("Gemsneeded", 2);
        UpdateText();
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
        if (Time.time - lastAttackTime > attackDelay) {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

            bool enemyHit = false;

            foreach (Collider enemy in hitEnemies)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(attackDamage);
                    enemyHit = true;
                }
            }

            if (enemyHit)
            {
                hit.Play();
            }
            else
            {
                nothit.Play();
            }

            lastAttackTime = Time.time;
        }
    }
    
    public void UpgradeSword() 
    {
        if (inventory.sticks > sticksneeded & inventory.gems > gemsneeded)
        {
            inventory.sticks -= sticksneeded;
            inventory.gems -= gemsneeded;
            attackDamage += 5;
            sticksneeded *= 2;
            gemsneeded *= 2;
            PlayerPrefs.SetInt("AttackDamage", attackDamage);
            PlayerPrefs.SetInt("Sticksneeded", sticksneeded);
            PlayerPrefs.SetInt("Sticksneeded", gemsneeded);
            shopUI.UpdateUI();
            UpdateText();
        }
        
    }
    private void UpdateText()
    {
        sticksneededText.text = sticksneeded.ToString();
        gemsneededText.text = gemsneeded.ToString();

    }

    void OnDrawGizmosSelected()
    {
        // Draw a sphere in the scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Find all colliders within the sphere
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        // Draw a box around each enemy in the scene view
        Gizmos.color = Color.green;
        foreach (Collider enemy in hitEnemies)
        {
            Gizmos.DrawWireCube(enemy.transform.position, enemy.bounds.size);
        }
    }
}
