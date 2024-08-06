using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Attack(IDamageDealer attacker, IDamageable target)
    {
        float damage = CalculateDamage(attacker.Strength, target.Defense);
        target.TakeDamage(damage);
    }

    private float CalculateDamage(float str, float def)
    {
        float damage = Mathf.Floor(str / (str + def) * str);
        return Mathf.Max(damage, 1); //avoid 0 damage.
    }
}
