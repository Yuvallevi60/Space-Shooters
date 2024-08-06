using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().ActivateShield();
            Destroy(gameObject);
        }
    }
}
