using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float rotationSpeed = 360f; // Rotation speed in degrees per second
    [SerializeField] private float threshold = 0.1f; 

    private Transform playerTransform;
    private Vector2 targetPos;
    private Vector2 attackDirection;
    private Quaternion targetRotation;

    private bool isOnTarget;
    private bool isNeedRotation;

    // Boundaries' position
    private float leftX;
    private float topY;
    private float rightX;
    private float bottomY;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // set the Boundaries' position properties
        float offsetX = GetComponent<SpriteRenderer>().bounds.extents.x; // half the object witdth
        float offsetY = GetComponent<SpriteRenderer>().bounds.extents.y; // half the object hight
        GameObject Boundaries = GameObject.Find("Boundaries");
        leftX = Boundaries.transform.Find("Left").gameObject.transform.position.x + offsetX;
        topY = Boundaries.transform.Find("Top").gameObject.transform.position.y - offsetY;
        rightX = Boundaries.transform.Find("Right").gameObject.transform.position.x - offsetX;
        bottomY = Boundaries.transform.Find("Bottom").gameObject.transform.position.y + offsetY;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnTarget)
            SetDirectionAndRotation();
        
        transform.Translate(Speed * Time.deltaTime * attackDirection, Space.World);

         if (isNeedRotation)
            Rotate();

        if (Vector2.Distance(transform.position, targetPos) < threshold)
            isOnTarget = false;
        else
            StayInBoundaries();
    }

    private void SetDirectionAndRotation()
    {
        targetPos = playerTransform.position;
        Vector2 currentPos = transform.position;
        attackDirection = (targetPos - currentPos).normalized;
        isOnTarget = true;

        // Set the Rotation needed to face the target     
        float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg - 90f; // Calculate the angle in degrees       
        targetRotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Calculate the target rotation
        isNeedRotation = true;
    }


    private void Rotate()
    {
        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (transform.rotation == targetRotation)
            isNeedRotation = false;
    }


    private void StayInBoundaries()
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
        {
            transform.position = objPos;
            isOnTarget = false;
        }
    }
}
