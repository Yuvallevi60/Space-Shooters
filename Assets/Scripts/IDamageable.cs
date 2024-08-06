using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageable
{
    float Defense { get; }

    public void TakeDamage(float damage);
}
