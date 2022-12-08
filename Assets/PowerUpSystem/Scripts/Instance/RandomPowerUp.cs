using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Up/Random", fileName = "NewRandom")]
public class RandomPowerUp : PowerUpObject
{

    [Space] [SerializeField] private PowerUpObject[] m_randomPowerUpList;

    private PowerUpObject _currentPowerUp;
    public override void Activate(GolfPlayer golfPlayer)
    {
        base.Activate(golfPlayer);

        var randomPowerUpIndex = Random.Range(0, m_randomPowerUpList.Length - 1);
        _currentPowerUp = m_randomPowerUpList[randomPowerUpIndex];
        m_powerUpData.ActiveDuration = _currentPowerUp.GetPowerUpDuration;
        _currentPowerUp.Activate(golfPlayer);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _currentPowerUp.Deactivate();
    }
}
