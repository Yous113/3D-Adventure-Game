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
    private bool isChasing;
    private bool isShooting;

    private void Start()
    {

        bossSlime = GetComponent<BossSlime>();
        bossShoot = GetComponent<BossShoot>();

        isChasing = true;
        isShooting = false;
        timer = chaseDuration;
        bossSlime.StartMoving();
        bossShoot.StopShooting();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (isChasing)
        {
            if (timer <= 0f)
            {
                bossSlime.StopMoving();
                isChasing = false;
                isShooting = true;
                timer = shootDuration;
                bossShoot.StartShooting();
            }
        }
        else if (isShooting)
        {
            if (timer <= 0f)
            {
                bossShoot.StopShooting();
                isShooting = false;
                timer = idleDuration;
            }
        }
        else
        {
            if (timer <= 0f)
            {
                bossSlime.StartMoving();
                isChasing = true;
                timer = chaseDuration;
            }
        }
    }
}
