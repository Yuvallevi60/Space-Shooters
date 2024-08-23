using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private float destroyDelay = 1.0f;
    [SerializeField] private float pullingSpeed = 10f; // How fast the coin are pulled towards the player

    private UnityEngine.Transform playerTransform;
    private bool isPulled = false;

    

    private void Update()
    {
        if (isPulled)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(pullingSpeed * Time.deltaTime * direction);
        }
    }

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

    public void PullToPlayer()
    {
        playerTransform = GameObject.Find("Player").transform;
        isPulled = true;
    }
}
