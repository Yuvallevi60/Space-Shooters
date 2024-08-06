using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StayInBoundaries : MonoBehaviour
{
    private float leftX;
    private float topY;
    private float rightX;
    private float bottomY;

    private void Start()
    {
        GameObject Boundaries = GameObject.Find("Boundaries");

        leftX = Boundaries.transform.Find("Left").gameObject.transform.position.x;
        topY = Boundaries.transform.Find("Top").gameObject.transform.position.y;
        rightX = Boundaries.transform.Find("Right").gameObject.transform.position.x;
        bottomY = Boundaries.transform.Find("Bottom").gameObject.transform.position.y;

        float offsetX = GetComponent<SpriteRenderer>().bounds.extents.x; // half the object witdth
        float offsetY = GetComponent<SpriteRenderer>().bounds.extents.y; // half the object hight

        leftX += offsetX;
        topY -= offsetY;
        rightX -= offsetX;
        bottomY += offsetY;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objPos = transform.position;
        bool isClamped = false;
        if (objPos.x < leftX || objPos.x > rightX)
        {
            objPos.x = Mathf.Clamp(objPos.x, leftX, rightX);
            isClamped = true;
        }
        if (objPos.y < bottomY || objPos.y > topY)
        {
            objPos.y = Mathf.Clamp(objPos.y, bottomY, topY);
            isClamped = true;
        }
        if (isClamped)
            transform.position = objPos;
    }
}
