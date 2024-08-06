using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float strength = 2f;
    public float Strength => strength;

    private Vector2 direction;

    public ParticleSystem HitExploasionEffect;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
        StartCoroutine(nameof(SelfDestruct));
    }

    public void Initialize(Vector2 targetPos, float speed)
    {
        this.speed = speed;
        Vector2 currentPos = transform.position;
        direction = (targetPos - currentPos).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the shot to face the target position
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Shot") || collision.gameObject.CompareTag("PlayerShield"))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            if (damageable != null)
                DamageManager.Instance.Attack(this, damageable);

            Instantiate(HitExploasionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
