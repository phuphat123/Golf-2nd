using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform TpPoint;
    public GameObject ball;
    public AudioClip potSound;

    [SerializeField] private bool isIn;
    
    IEnumerator check() {
        yield return new WaitForSeconds(1);
        teleport();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isIn = true;
            StartCoroutine(check());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isIn = false;
        }
    }

    void teleport() {
        if (isIn)
        {
            AudioSource.PlayClipAtPoint(potSound, transform.position);
            player.transform.position = TpPoint.transform.position;
            ball.GetComponent<GolfPlayer>().Stop();
        }
        else {
            return;
        }
    }
    

}
