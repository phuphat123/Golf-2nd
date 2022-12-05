using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SizeUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public float multiplier = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    private void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= multiplier;
        
    }
}
