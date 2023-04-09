using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 20f;
    [SerializeField] private Playerhealth Player;

    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    private void Update()
    {
        currentHealth = Player.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
