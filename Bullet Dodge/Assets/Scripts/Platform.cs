using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Platform : MonoBehaviour
{
    public float timer = 0f;
    public float fallTime = 3f;

    public GameObject[] grounds;

    private int curr;

    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > fallTime)
        {
            grounds[curr].gameObject.SetActive(true);
            curr = Random.Range(0, grounds.Length);
            grounds[curr].gameObject.SetActive(false);
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }



    }
}
