using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public Dropdown resDropdown;
    Resolution[] resolutions; // creating an array for resolutions
    
    // Start is called before the first frame update
    private void Start()
    {
        
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions(); // clears resolutions in the dropdown before adding users res

        List<string> options = new List<string>(); //creating list for the all the resolutions
        int currentResolutionIndex = 0;
        // loops through all resolutions in the array
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; // each element creating string for width and length of resolution 
            options.Add(option); // adds res options to list 
            // checks for resolution of the users screen by comparing width and height
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        resDropdown.AddOptions(options);// add res to dropdown
        resDropdown.value = currentResolutionIndex;// sets the value of users screen 
        resDropdown.RefreshShownValue();




    }
    // checks if users screen is in fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    // Mainmenu volume mixer
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        mainMixer.SetFloat("volume", volume);
    }
    // graphic settings
    public void SetQuality(int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    public void disableMenu() {
        
    }
    public void enableMenu() {
        
    }
}