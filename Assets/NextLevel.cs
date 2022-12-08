using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{

    // Start is called before the first frame update
    
    
    public AudioClip completionMusic;

    [SerializeField] private GameObject BUTTON; 

    [SerializeField] private bool isIn;
    MeshRenderer m;
    guiScript reference;

    private void Start()
    {
        m = gameObject.GetComponent<MeshRenderer>();
        reference = GetComponent<guiScript>();
        TurnTheGUIOff();
        m.enabled = false;
    }
    IEnumerator check()
    {
        yield return new WaitForSeconds(1);
        LoadButton();
        
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

    void LoadButton() {
        if (isIn) {
            TurnTheGUIOn();
            AudioSource.PlayClipAtPoint(completionMusic, transform.position); }
        else { return; }
        
        
    }
    public void LoadNextLevel() {


        if (SceneManager.sceneCount < SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(completionMusic);
        }
        
        
    }

    public void TurnTheGUIOn()
    {
        reference.enabled = true;
    }

    public void TurnTheGUIOff()
    {
        reference.enabled = false;
    }


}
