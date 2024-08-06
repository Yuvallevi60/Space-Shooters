using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour, IDamageable
{
    private float maxHealth;
    [SerializeField] private float health; // will not be set until the shield activated
    [SerializeField] private HealthBar healthBar;

    [SerializeField] private float defense = 1f;
    public float Defense => defense;


    void Awake()
    {
        maxHealth = GameManager.Instance.playerStats.ShieldHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    public void Activate()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
            healthBar.gameObject.SetActive(true);
        }
        UpdateHealth(maxHealth - health); // set the health to full
    }

    public void TakeDamage(float damage)
    {
        UpdateHealth(-damage);
    }

    private void UpdateHealth(float val)
    {
        health += val;

        healthBar.SetHealth(health);

        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false); // disabled the shield
            healthBar.gameObject.SetActive(false);
        }
    }
}
