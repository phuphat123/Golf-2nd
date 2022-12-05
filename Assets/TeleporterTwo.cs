using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterTwo : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform TpPoint2;


    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = TpPoint2.transform.position;
        }
    }
}
