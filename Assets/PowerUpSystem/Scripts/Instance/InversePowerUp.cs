using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Up/Inverse", fileName = "NewInverse")]
public class InversePowerUp : PowerUpObject
{
    public override void Activate(GolfPlayer golfPlayer)
    {
        base.Activate(golfPlayer);

        golfPlayer.GetComponent<Rigidbody>().velocity *= -1;
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}
