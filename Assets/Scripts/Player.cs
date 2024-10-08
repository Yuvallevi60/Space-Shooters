using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private HealthBar healthBar;

    [SerializeField] private float defense;
    public float Defense => defense;

    [SerializeField] private float AutoHealPerSec;

    [SerializeField] private GameObject Shield;

    private bool isMagnetActive;
    private float magnetDuration; // Duration of the magnet effect

    void Start()
    {
        defense = GameManager.Instance.playerStats.GetStatValue("Defense");
        health = maxHealth = GameManager.Instance.playerStats.GetStatValue("MaxHealth");
        healthBar.SetMaxHealth(maxHealth);
        magnetDuration = GameManager.Instance.playerStats.MagnetDuration;

        AutoHealPerSec = maxHealth / 100 * GameManager.Instance.playerStats.AutoHealPrecent;
        InvokeRepeating(nameof(AutoHeal), 1, 1);
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0 && !Shield.activeInHierarchy)
        {   
            UpdateHealth(-damage);
            if (health <= 0)
                EventManager.Instance.GameOver();
        }
    }

    public void UpdateHealth(float value)
    {
        health = Mathf.Min(health + value, maxHealth);
        healthBar.SetHealth(health);
    }

    private void AutoHeal()
    {
        UpdateHealth(AutoHealPerSec);
    }

    public void ActivateShield()
    {
        Shield.GetComponent<PlayerShield>().Activate();
    }

    public void ActivateMagnet()
    {
        if (!isMagnetActive)
            isMagnetActive = true;
        else
            StopCoroutine(MagnetCoroutine());
        StartCoroutine(MagnetCoroutine());
    }

    private IEnumerator MagnetCoroutine()
    {
        float magnetTimer = 0;

        while (magnetTimer < magnetDuration)
        {
            magnetTimer += Time.deltaTime;
            foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin"))
                coin.GetComponent<Coin>().PullToPlayer();
            
            yield return null;
        }

        isMagnetActive = false;
    }
}
