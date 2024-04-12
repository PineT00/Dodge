using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rSpeed = 360f;


    void Update()
    {
        transform.Rotate(0f, rSpeed * Time.deltaTime, 0f);
    }
}
