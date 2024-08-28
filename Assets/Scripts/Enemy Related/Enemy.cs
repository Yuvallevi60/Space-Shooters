using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IDamageDealer
{
    [SerializeField] private int scorePoints;
    [SerializeField] private float health;

    [SerializeField] private float defense;
    public float Defense => defense;

    [SerializeField] private float strength;
    public float Strength => strength;

    [SerializeField] private GameObject damagePopup;

    // Relate to attacking the chicken
    [SerializeField] private ParticleSystem BloodDropEffect;
    [SerializeField] private ParticleSystem ExploasionEffect;
    private float pushBackDistance = 0.2f;

    // Relate to the drops after thew enemy killed
    [SerializeField] private float DropRate;
    [SerializeField] private LootTable lootTable;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerShield"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
                DamageManager.Instance.Attack(this, damageable);
            Death(false);
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            transform.position += new Vector3(0, pushBackDistance, 0); // Push back
            Instantiate(BloodDropEffect, transform.position, Quaternion.identity); //blood effect
            GameObject dPopup = Instantiate(damagePopup, transform.position, Quaternion.identity); //Damage Popup
            dPopup.GetComponent<DamagePopup>().SetDamageText(damage.ToString());

            health -= damage;
            if (health <= 0)
                Death(true);
        }
    }

    protected void Death(bool isDrop)
    {
        GameManager.Instance.currentPlayStats.EnemiesKilled++;
        EventManager.Instance.ScoreChanged(scorePoints); // Add score when chicken is killed              
        if (isDrop)
            HandleDrops();
        Instantiate(ExploasionEffect, transform.position, Quaternion.identity); // ExploasionEffect
        Destroy(gameObject);
    }

    // handle the drops from the enemy when he is defeted
    private void HandleDrops()
    {
        if (Random.value > DropRate)
            return;

        float totalWeight = 0f;
        foreach (DropItem dropItem in lootTable.DropItems)
            totalWeight += dropItem.DropRate;

        float randomValue = Random.value * totalWeight;
        foreach (DropItem dropItem in lootTable.DropItems)
        {
            if (randomValue < dropItem.DropRate)
            {
                GameObject drop = Instantiate(dropItem.Prefab, transform.position, Quaternion.identity);
                return; // Ensure only one item is dropped
            }
            randomValue -= dropItem.DropRate;
        }
    }
}
