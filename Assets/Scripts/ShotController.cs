using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float strngth = 5f;
    public float Strength => strngth;

    [SerializeField] private float destroyDelay = 1.0f;

    void Start()
    {
        strngth *= GameManager.Instance.playerStats.Strength;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
        StartCoroutine(nameof(SelfDestruct));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy Shot"))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            if (damageable != null)
                DamageManager.Instance.Attack(this, damageable);

            // delied destory of the coin for the sound to be played
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;
            Destroy(gameObject, destroyDelay);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }    
}
