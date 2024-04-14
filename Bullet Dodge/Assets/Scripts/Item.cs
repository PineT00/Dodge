using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.CompareTag("Player")))
        {
            var player = collision.GetComponent<PlayerController>();
            if (!player.isInvincible)
            {
                player.isInvincible = true;
            }
            Destroy(gameObject);
        }
    }
}
