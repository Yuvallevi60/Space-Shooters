using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    // boundaries positions of the camera movment
    private float leftX;
    private float topY;
    private float rightX;
    private float bottomY;

    //[SerializeField] private float followSpeed = 10f;
    //// threshold distance from the edge of the screen
    //private float thresholdX;
    //private float thresholdY;
    //// Percentage of the screen's width to use as the threshold
    //[SerializeField] private float edgeThresholdPercentage = 0.4f;


    private void Start()
    {
        float worldScale = GameManager.Instance.gameSettings.WorldScale;
        GameObject boundaries = GameObject.Find("Boundaries");

        // Get the positions of the boundary children and adjust them acording to the "World Sale"
        leftX = boundaries.transform.Find("Left").position.x * worldScale;
        topY = boundaries.transform.Find("Top").position.y * worldScale;
        rightX = boundaries.transform.Find("Right").position.x * worldScale;
        bottomY = boundaries.transform.Find("Bottom").position.y * worldScale;

        // Calculate the screen's width and height in world units
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = Camera.main.aspect * cameraHeight;

        // aduject scence boundaries' positions with an offset that is the camera size
        leftX += (cameraWidth);
        rightX -= (cameraWidth);
        topY -= (cameraHeight);
        bottomY += (cameraHeight);

        //// Calculate the threshold distance from the edge of the screen
        //thresholdX = cameraWidth * (1 - edgeThresholdPercentage);
        //thresholdY = cameraHeight * (1 - edgeThresholdPercentage);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position;

        float clampedX = Mathf.Clamp(targetPosition.x, leftX, rightX);
        float clampedY = Mathf.Clamp(targetPosition.y, bottomY, topY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        //Vector3 targetPosition = target.position;

        //// Check if the player's position is outside the threshold distance from the edge
        //bool outsideLeftThreshold = targetPosition.x < transform.position.x - thresholdX;
        //bool outsideRightThreshold = targetPosition.x > transform.position.x + thresholdX;
        //bool outsideBottomThreshold = targetPosition.y < transform.position.y - thresholdY;
        //bool outsideTopThreshold = targetPosition.y > transform.position.y + thresholdY;

        //if (outsideLeftThreshold || outsideRightThreshold || outsideBottomThreshold || outsideTopThreshold)
        //{
        //    // make sure the camera's view is within the scene's bounderies
        //    float clampedX = Mathf.Clamp(targetPosition.x, leftX, rightX);
        //    float clampedY = Mathf.Clamp(targetPosition.y, bottomY, topY);

        //    // Use Vector3.MoveTowards to smoothly move the camera towards the clamped position
        //    Vector3 desiredPosition = new Vector3(clampedX, clampedY, transform.position.z);
        //    transform.position = Vector3.MoveTowards(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        //}
    }
}