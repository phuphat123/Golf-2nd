using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PowerUpData
{
    [SerializeField] private string m_name;
    [SerializeField] private float m_activeDuration;

    public string Name => m_name;

    public float ActiveDuration
    {
        get => m_activeDuration;
        set => m_activeDuration = value;
    }
}

