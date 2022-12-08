using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PowerUpHolder : MonoBehaviour
{

    [Header("Config:")]
    [SerializeField] protected PowerUpObject m_powerUpAsset;
    [SerializeField] protected GameObject m_visualObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out GolfPlayer golfPlayer))
            StartCoroutine(ApplyPowerUp(golfPlayer));
    }

    private IEnumerator ApplyPowerUp(GolfPlayer golfPlayer)
    {
        Destroy(m_visualObject);
        GetComponent<Collider>().enabled = false;
        m_powerUpAsset.Activate(golfPlayer);
        yield return new WaitForSeconds(m_powerUpAsset.GetPowerUpDuration);
        m_powerUpAsset.Deactivate();
        Destroy(gameObject);
    }
}
