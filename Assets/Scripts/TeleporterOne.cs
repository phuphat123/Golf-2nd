using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform TpPoint;
    public GameObject ball;
    public AudioClip potSound; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(potSound, transform.position);
            player.transform.position = TpPoint.transform.position;
            ball.GetComponent<GolfPlayer>().Stop();
        }

    }
    

}
