using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private float val;

    private void Start()
    {
        val = GameManager.Instance.playerStats.HeartHealVal;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().UpdateHealth(val);
            Destroy(gameObject);
        }
    }
}
