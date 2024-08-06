using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float posXOffset = 2f;
    [SerializeField] private float posXRange;



    // Start is called before the first frame update
    void Start()
    {
        // set x range of spawning
        GameObject Boundaries = GameObject.Find("Boundaries");
        float rightX = Boundaries.transform.Find("Right").gameObject.transform.position.x;
        posXRange = rightX - posXOffset;

        float posY = Boundaries.transform.Find("Top").gameObject.transform.position.y;
        transform.position = new Vector2(transform.position.x, posY + 1f);   

        spawnRate = GameManager.Instance.gameSettings.SpawnRate;

        InvokeRepeating(nameof(EnemySpawn), 0, spawnRate);
    }


    private void EnemySpawn()
    {
        float posX = Random.Range(-posXRange, posXRange);
        Vector2 spawnPos = new (posX, transform.position.y);
        int index = Random.Range(0, EnemyPrefab.Length);
        Instantiate(EnemyPrefab[index], spawnPos, EnemyPrefab[index].transform.rotation);
    }
}
