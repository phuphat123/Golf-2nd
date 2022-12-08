using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Up/Size Up", fileName = "NewSizeUp")]
public class SizeUpPowerUp : PowerUpObject
{

    [Space] [SerializeField] private float m_sizeMultiplier = 3;
    
    public override void Activate(GolfPlayer golfPlayer)
    {
        base.Activate(golfPlayer);
        
        GolfPlayer.transform.localScale *= m_sizeMultiplier; // increase size of player by 2

    }

    public override void Deactivate()
    {
        base.Deactivate();
        
        GolfPlayer.transform.localScale /= m_sizeMultiplier; // return the size of player to normal

    }
}
