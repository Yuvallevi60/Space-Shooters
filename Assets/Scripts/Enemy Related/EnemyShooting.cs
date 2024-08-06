using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject ShotPrefab;
    [SerializeField] private float ShotSpeed;
    [SerializeField] private float shootingInterval;

    private Transform playerTransform;
    private float lastShootTime;
    private bool isReadyToShoot;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        lastShootTime = Time.time;
    }

    private void Update()
    {
        if (isReadyToShoot)
        {
            if (IsVisibleByCamera())
            {
                Shoot();
                lastShootTime = Time.time;
                isReadyToShoot = false;
            }
        }
        else if (Time.time - lastShootTime >= shootingInterval)
        {
            isReadyToShoot = true;
        } 
    }

    private void Shoot()
    {
        if (playerTransform != null)
        {           
            Vector2 playerPos = playerTransform.position; 

            GameObject shot = Instantiate(ShotPrefab,transform.position, Quaternion.identity); 

            // Initialize the shot with the target position and speed
            EnemyShotController shotMover = shot.GetComponent<EnemyShotController>();
            if (shotMover != null)
                shotMover.Initialize(playerPos, ShotSpeed);
        }
    }

    private bool IsVisibleByCamera()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        var point = GetComponent<Collider2D>().bounds;
        return GeometryUtility.TestPlanesAABB(planes, point);
    }
}
