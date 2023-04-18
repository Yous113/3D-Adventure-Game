using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [Header("AttackVariables")]
    public GameObject projectilePrefab;
    public float attackInterval = 2f;
    public float projectileSpeed = 30f;
    public int projectileDamage = 5;
    public float projectileMass = 1f;
    public float projectileDrag = 0.1f;


    [Header("Colliders")]
    [SerializeField] Collider collider1;
    [SerializeField] Collider collider2;
    private float attackTimer;

    private void Start()
    {
        attackTimer = attackInterval;
        collider1 = GetComponent<Collider>();
    }

    private void Update()
    {
        if (attackInterval != float.MaxValue)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                LaunchProjectile();
                attackTimer = attackInterval;
            }
        }
    }

    private void LaunchProjectile()
    {
        Transform spawnPosition = transform.Find("ProjectileSpawnPosition");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 directionToPlayer = player.transform.position - spawnPosition.position;

        GameObject projectile = Instantiate(projectilePrefab, spawnPosition.position, Quaternion.identity);
        collider2 = projectile.GetComponent<Collider>();
        Physics.IgnoreCollision(collider1, collider2, true);

        projectile.transform.rotation = Quaternion.LookRotation(directionToPlayer);

        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.mass = projectileMass;
        projectileRigidbody.drag = projectileDrag;

        projectileRigidbody.velocity = directionToPlayer.normalized * projectileSpeed;

        ProjectileBehavior projectileBehavior = projectile.GetComponent<ProjectileBehavior>();
        projectileBehavior.SetDamage(projectileDamage);
    }

    public void StartShooting()
    {
        attackInterval = 0.5f;
        Debug.Log("Boss is now shooting.");
    }

    public void StopShooting()
    {
        attackInterval = float.MaxValue;
        Debug.Log("Boss stopped shooting.");
    }
}
