using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    // Parameters for advacning down the screen
    [SerializeField] private float speed = 0.6f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }
}
