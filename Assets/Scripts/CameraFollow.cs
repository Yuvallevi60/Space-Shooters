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
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameSettings.WorldScale > 1)
        {
            Vector3 targetPosition = target.position;

            float clampedX = Mathf.Clamp(targetPosition.x, leftX, rightX);
            float clampedY = Mathf.Clamp(targetPosition.y, bottomY, topY);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}