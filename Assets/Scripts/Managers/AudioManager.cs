using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

// [Serializable] public class VoiceLines : SerializableDictionary<string, AudioClip> { }
public class AudioManager : MonoBehaviour
{
    [SerializeField] bool amIWorking;
    AudioSource audioPlayer;
    [Header("More Sounds")]
    [SerializeField] AudioSource robiVoice;
    [SerializeField] AudioSource manYell;
    // public VoiceLines robiLines;


    // load robi's lines into a dictionary with the name of the file as key

    Dictionary<string, AudioClip> robiLines = new Dictionary<string, AudioClip>();
    Object[] temp;

    


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


        //put robi lines into dictionary
        temp = Resources.LoadAll("Robi", typeof(AudioClip));
        foreach (AudioClip line in temp){
            robiLines.Add(line.name, line);
        }
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

    public void PauseBGM(){
        audioPlayer.Pause();
    }

    public void ResumeBGM(){
        audioPlayer.Play();
    }

    public void PlayRobiLine(string line){
        AudioClip lineToPlay;
        lineToPlay = robiLines[line];
        if(lineToPlay != null){
            robiVoice.clip = lineToPlay;
            robiVoice.Play();
        }
    }

    public void StartManYell(){
        manYell.Play();
    }

    public void StopManYell(){
        manYell.Pause();
    }
}
