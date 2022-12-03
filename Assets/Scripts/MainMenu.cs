using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // When button Start is clicked it loads scene 1
    public void ClickToStart()
    {
        Debug.Log("Load Scene 1");
        SceneManager.LoadScene(1); // First level
    }
    // When button Quit is clicked it quits game
    public void ClickToQuit()
    {
        Debug.Log("Game has closed!");
        Application.Quit(); // Quits application
    }
}
