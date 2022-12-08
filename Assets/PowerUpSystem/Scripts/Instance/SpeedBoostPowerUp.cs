using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Up/Speed Boost", fileName = "NewSpeedBoost")]
public class SpeedBoostPowerUp : PowerUpObject
{
    [Space] [SerializeField] private float m_speedMultiplier = 3;
    
    public override void Activate(GolfPlayer golfPlayer)
    {
        base.Activate(golfPlayer);
        var golfPhysicBody = GolfPlayer.GetComponent<Rigidbody>();
        golfPhysicBody.velocity *= m_speedMultiplier;
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}
