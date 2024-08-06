using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovement : MonoBehaviour
{
    public float dropUpwardForce = 5f; // Force to apply to the coin
    private float speed = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<Rigidbody2D>().AddForce(Vector2.up * dropUpwardForce, ForceMode2D.Force);        
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}

