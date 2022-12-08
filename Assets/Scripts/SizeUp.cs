using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SizeUp : MonoBehaviour
{
    
    public float multiplier = 2f;
    public float duration = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        player.transform.localScale *= multiplier; // increase size of player by 2
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration); // wait for 3 seconds 
        player.transform.localScale /= multiplier; // return the size of player to normal
        Destroy(gameObject);
    }
}
