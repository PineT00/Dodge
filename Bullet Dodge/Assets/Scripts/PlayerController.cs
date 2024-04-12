using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 10f;
    public float rSpeed = 100f;
    public Rigidbody rb;

    public bool isInvincible = false;

    Vector3 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        dir = new Vector3(0f, -9.8f * Time.deltaTime, 0f);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        dir.x = h;
        dir.z = v;



        if (dir.magnitude > 1f)
        {
            dir.Normalize();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            dir.y += 10f * Time.deltaTime;
            rSpeed = 400f;
            isInvincible = true;
            rb.velocity = dir * speed;
        }
        else
        {
            isInvincible = false;
            dir.y = -30f * Time.deltaTime;
            rb.velocity = dir * speed;
            rSpeed = 1f;
        }
        rb.rotation = Quaternion.Euler(0f, rSpeed * Time.deltaTime, 0f);


    }

    public void OnDie()
    {
        gameObject.SetActive(false);
        gameManager.EndGame();
    }

}
