using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class VoiceLines : SerializableDictionary<string, AudioClip> { }
public class AudioManager : MonoBehaviour
{
    [SerializeField] bool amIWorking;
    AudioSource audioPlayer;
    [Header("Robi Talking")]
    [SerializeField] AudioSource robiVoice;
    [SerializeField] VoiceLines robiLines;
    


    private static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Found more than one Audio Manager in the scene");
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
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
            audioPlayer.Play();
        }
        else
        Debug.Log("no clip");
        
    }

    public void PauseBGM(){
        audioPlayer.Pause();
    }

    public void ResumeBGM(){
        audioPlayer.Play();
    }

    public void PlayRobiLine(string line){

    }
}
