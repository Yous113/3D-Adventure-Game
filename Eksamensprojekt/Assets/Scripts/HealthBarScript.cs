using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [Header("UI")]
    private Image healthBar;

    [Header("Health")]
    public float currentHealth;
    private float maxHealth = 20f;
    [SerializeField] private Playerhealth Player;

    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    private void Update()
    {
        UpdateHealthbar();
    }
    public void UpdateHealthbar()
    {
        currentHealth = Player.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
    
}
