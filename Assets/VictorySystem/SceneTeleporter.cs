using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    
    [SerializeField] private string m_nextScene;
    [SerializeField] private GameObject m_victoryBanner;
    [SerializeField] private float m_victoryBannerShowDuration = 4;
    public GameObject ball;
    public AudioClip potSound;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(VictoryState());
        }

    }

    private IEnumerator VictoryState()
    {
        AudioSource.PlayClipAtPoint(potSound, transform.position);
        ball.GetComponent<GolfPlayer>().Stop();
        m_victoryBanner.SetActive(true);
        yield return new WaitForSeconds(m_victoryBannerShowDuration);
        SceneManager.LoadScene(m_nextScene);
    }
    
}
