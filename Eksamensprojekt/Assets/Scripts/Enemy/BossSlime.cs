using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : MonoBehaviour
{
    public float moveSpeed = 1f;
    private GameObject[] players;
    private GameObject closestPlayer;
    private float closestDistance = Mathf.Infinity;
    public float damageAmount = 10f;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        if (!closestPlayer || !closestPlayer.activeSelf)
        {
            closestDistance = Mathf.Infinity;
            foreach (GameObject player in players)
            {
                if (!player.activeSelf) continue;
                
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (distanceToPlayer < closestDistance)
                {
                    closestPlayer = player;
                    closestDistance = distanceToPlayer;
                }
            }
        }

        if (closestPlayer && closestPlayer.activeSelf)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestPlayer.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Playerhealth>().TakeDamage(damageAmount);
        }
    }

    public void StartMoving()
    {
        moveSpeed = 1f;
    }

    public void StopMoving()
    {
        moveSpeed = 0f;
    }

}

