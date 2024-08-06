using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private float destroyDelay = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            //get value of the coin
            int value = Random.Range(GameManager.Instance.playerStats.CoinMinValue, GameManager.Instance.playerStats.CoinMaxValue + 1);
            EventManager.Instance.MoneyChanged(value);

            GetComponent<AudioSource>().Play();

            // delied destory of the coin for the sound to be played
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, destroyDelay);
        }
    }
}
