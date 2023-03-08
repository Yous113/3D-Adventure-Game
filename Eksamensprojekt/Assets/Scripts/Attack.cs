using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private CharacterController controller;
    public LayerMask enemyLayer;
    public float damageAmount = 5f;

    public void OnHit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.right, out hit, Mathf.Infinity, enemyLayer))
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    print("takes damage");
                    enemy.TakeDamage(damageAmount);
                }
            }
        }
    }
}