using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class guiScript : MonoBehaviour
{
    NextLevel nextlvl;
    Pause pausemenu;
    [SerializeField] private int l;
    [SerializeField] private int m;

    private void Awake()
    {
        nextlvl = GetComponent<NextLevel>();
        pausemenu = GameObject.Find("Canvas").GetComponent<Pause>();

    }
    void OnGUI()
    {
        pausemenu.enabled = false;
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            if (GUI.Button(new Rect(Screen.width / 2-100, Screen.height / 2-40, 200, 80), "Next"))
            {
                nextlvl.LoadNextLevel();
                nextlvl.TurnTheGUIOff();
            }
            
        }
        else {
            
            if (GUI.Button(new Rect(Screen.width / 2-100, Screen.height / 2-40, 200, 80), "Main Menu"))
            {

                nextlvl.LoadNextLevel();
                nextlvl.TurnTheGUIOff();
            }
        }
        
    }
    

    
}
