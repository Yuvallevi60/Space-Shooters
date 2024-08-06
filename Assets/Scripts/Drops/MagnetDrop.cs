using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().ActivateMagnet();
            Destroy(gameObject);
        }
    }
}
