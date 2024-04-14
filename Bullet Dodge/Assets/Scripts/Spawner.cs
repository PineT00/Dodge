using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefeb;

    float minInterval = 1f;
    float maxInterval = 2f;

    float nextSpawnTime;

    public PlayerController player;

    private void Start()
    {
        var findGo = GameObject.FindWithTag("Player");
        if(findGo != null)
        {
            player = findGo.GetComponent<PlayerController>();
        }
        nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {

        if (Time.time > nextSpawnTime)
        {
            CreateBullet();
            nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
        }
    }

    private void CreateBullet()
    {
        Debug.Log("dddddddddddddddd");
        var direction = player.transform.position - transform.position;
        direction.Normalize();
        var targetRotation = Quaternion.LookRotation(direction);
        Instantiate(prefeb, transform.position, targetRotation);
    }

}
