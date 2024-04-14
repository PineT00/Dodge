using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 10f;
    public float rSpeed = 100f;
    public float gravity = 1f;
    public Rigidbody rb;

    public bool isInvincible = false;
    private float invinsibleTime = 5f;

    Vector3 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        dir = new Vector3(0f, -gravity * Time.deltaTime, 0f);
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        dir.x = h;
        dir.z = v;
        dir.y = -gravity * Time.deltaTime;

        if (dir.magnitude > 1f)
        {
            dir.Normalize();
        }

        if(isInvincible)
        {
            rSpeed = 800f;
            invinsibleTime -= Time.deltaTime;
        }
        else
        {
            rSpeed = 0f;
        }
        if(invinsibleTime <= 0f)
        {
            isInvincible = false;
            invinsibleTime = 3f;
        }

        transform.Rotate(0f, rSpeed * Time.deltaTime, 0f);
        //rb.rotation = Quaternion.Euler(0f, rSpeed , 0f);
        rb.velocity = dir * speed;
    }

    public void OnDie()
    {
        gameObject.SetActive(false);
        gameManager.EndGame();
    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    if(GameObject.FindGameObjectWithTag("Platform"))
    //    {
    //        gravity = 1f;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (GameObject.FindGameObjectWithTag("Platform"))
    //    {
    //        gravity = 9.8f;
    //    }
    //}

}
