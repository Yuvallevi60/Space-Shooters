using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundaries : MonoBehaviour
{
    private float leftX;
    private float topY;
    private float rightX;
    private float bottomY;

    [SerializeField] private float offset = 2f;


    private void Start()
    {
        GameObject Boundaries = GameObject.Find("Boundaries");

        leftX = Boundaries.transform.Find("Left").gameObject.transform.position.x;
        topY = Boundaries.transform.Find("Top").gameObject.transform.position.y;
        rightX = Boundaries.transform.Find("Right").gameObject.transform.position.x;
        bottomY = Boundaries.transform.Find("Bottom").gameObject.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y > topY+offset) || (transform.position.y < bottomY-offset) || (transform.position.x > rightX+offset) || (transform.position.x < leftX-offset))
        {
            Destroy(gameObject);
        }
    }
}
