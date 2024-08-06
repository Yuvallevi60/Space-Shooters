using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private float destroyTime = 0.5f;
    [SerializeField] private Vector3 Offset = new Vector3(0, 1f,0);
    [SerializeField] private float XPosRange = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(UnityEngine.Random.Range(-XPosRange, XPosRange), 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDamageText(string text)
    {
        gameObject.GetComponent<TextMeshPro>().text = text;
    }
}
