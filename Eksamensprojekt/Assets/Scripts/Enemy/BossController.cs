using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossSlime bossSlime;
    public BossShoot bossShoot;

    public float chaseDuration = 10f;
    public float shootDuration = 5f;
    public float idleDuration = 5f;

    private float timer;
    public bool isChasing;
    public bool isShooting;

    private void Start()
    {
        bossSlime = GetComponent<BossSlime>();
        bossShoot = GetComponent<BossShoot>();
        timer = chaseDuration;
        isChasing = true;
        isShooting = false;

    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (isChasing)
        {
            if (timer > 0f)
            {
                isShooting = false;
            }

            if (timer <= 0f)
            {
                bossSlime.StopMoving();
                isChasing = false;
                isShooting = true;
                timer = shootDuration;
                Debug.Log("Boss is now shooting.");
            }
        }

        else if (isShooting)
        {
            if (timer <= 0f)
            {
                bossShoot.StopShooting();
                isShooting = false;
                timer = idleDuration;
                Debug.Log("Boss is now idle.");
            }
        }
        else
        {
            if (timer <= 0f)
            {
                bossSlime.StartMoving();
                isChasing = true;
                timer = chaseDuration;
                Debug.Log("Boss is now chasing.");
            }
        }
    }
}
