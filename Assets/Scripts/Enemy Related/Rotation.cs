using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Parameters for rotation motion
    [SerializeField] private float rotationAmplitude = 10f; // Amplitude of the rotation (max rotation angle)
    [SerializeField] private float rotationFrequency = 1f; // Frequency of the rotation (how fast it rotates)
    private float initialRotation;


    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.eulerAngles.z; // Store the initial rotation of the chicken
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAngle = initialRotation + Mathf.Sin(Time.time * rotationFrequency) * rotationAmplitude;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
