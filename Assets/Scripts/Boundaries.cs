using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = Vector3.one * GameManager.Instance.gameSettings.WorldScale;
    }
}
