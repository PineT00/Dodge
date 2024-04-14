using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject prefeb;

    float minInterval = 1f;
    float maxInterval = 2f;

    float nextSpawnTime;


    private void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            CreateItem();
            nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
        }
    }

    private void CreateItem()
    {
        Vector2 rng = Random.insideUnitCircle * 10; //Get a random position around a unit circle.
        var dir = new Vector3(rng.x, 1, rng.y);
        Instantiate(prefeb, dir, Random.rotation);
    }
}
