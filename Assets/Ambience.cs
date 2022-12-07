using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Ambience : MonoBehaviour
{
    // Start is called before the first frame update

    
    // Public variables
    // Will the sound play on startup?
    public bool playAtStartup;

    // The interval of time (in seconds) that the sound will be played.
    public float interval;

    public AudioMixer ambiMixer;
    
    // Private variables
    // A modifier that will prevent the script from running in the event of an error
    private bool disableScript = false;

    // The amount of time that has passed since the last initial playback of the sound.
    private float trackedTime = 0.0f;

    // Tracks to see if we've played this at startup.
    private bool playedAtStartup = false;
    public AudioSource _as;
    public AudioClip[] audioClipArray;
    [SerializeField] private int randomDebug;
    // Use this for initialization

    
    void Start()
    {
        
        _as = GetComponent<AudioSource>();

        if (interval < 1.0f)
        { // Make sure the interval isn't 0, or we'll be constantly playing the sound!
            Debug.LogError("Interval base must be at least 1.0!");
            disableScript = true;
        }
        
    }

    

    // Update is called once per frame
    void Update()
    {


        if (!disableScript)
        {
            int rand = Random.Range(0, audioClipArray.Length);
            Debug.Log("Random: " + rand);

            randomDebug = rand;
            // Play the sound when the scene starts
            if (playAtStartup) {
                _as.clip = audioClipArray[rand];
                _as.PlayOneShot(_as.clip);
                playAtStartup = false;
            }

            // Increment the timer
            trackedTime += Time.deltaTime;

            // Check to see that the proper amount of time has passed
            if (trackedTime >= interval)
            {
                // Play the sound, reset the timer
                randomDebug = rand;
                _as.clip = audioClipArray[rand];
                _as.PlayOneShot(_as.clip);
                trackedTime = 0.0f;
            }
        }
    }

    // ambience volume mixer
    public void SetVolume2(float volume)
    {
        Debug.Log(volume);
        ambiMixer.SetFloat("volume2", volume);
    }


}
