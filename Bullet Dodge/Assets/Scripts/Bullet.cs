using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = transform.forward * speed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }
    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.CompareTag("Player")))
        {
            var player = collision.GetComponent<PlayerController>();
            if (!player.isInvincible)
            {
                player.OnDie();
            }
            Destroy(gameObject);
        }

        //if ((collision.CompareTag("Wall")))
        //{
        //    Destroy(gameObject);
        //}

        Destroy(gameObject);
    }

}
