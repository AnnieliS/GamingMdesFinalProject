using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] bool amIWorking;
    AudioSource audioPlayer;

    private static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Audio Manager in the scene");
        }
        instance = this;
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        Debug.Log("audio " + audioPlayer);
    }


    public void SwitchBGM(AudioClip soundClip)
    {
        Debug.Log("sound clip " + soundClip);
        if (soundClip != null)
        {
            audioPlayer.clip = soundClip;
        }
        else
        Debug.Log("no clip");
        
    }
}
