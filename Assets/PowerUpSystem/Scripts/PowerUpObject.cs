using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpObject : ScriptableObject
{
    [Header("Config:")]
    [SerializeField] protected PowerUpData m_powerUpData;

    public PowerUpData GetPowerUpData => m_powerUpData;
    public string GetPowerUpName => m_powerUpData.Name;
    public float GetPowerUpDuration => m_powerUpData.ActiveDuration;

    public GolfPlayer GolfPlayer { get; protected set; }

    public virtual void Activate(GolfPlayer golfPlayer)
    {
        if (!GolfPlayer)
            GolfPlayer = golfPlayer;
    }

    public virtual void Deactivate()
    {
        
    }
    
}
