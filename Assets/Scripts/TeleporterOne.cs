using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterOne : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform TpPoint;
    public GameObject ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            player.transform.position = TpPoint.transform.position;
            ball.GetComponent<GolfPlayer>().Stop();
        }

    }
}
