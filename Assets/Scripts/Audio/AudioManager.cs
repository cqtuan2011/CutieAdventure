using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource effectSource, uiSource, musicSource;

    [SerializeField] private List<Audio> audios;

    private void Start()
    {
        PlayMusic("Background Music");
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private Audio FindAudio(string name)
    {
        var clip = audios.Find(x => x.name == name);
        return clip;
    }

    public void PlayUIEffectSound(string name)
    {
        var audio = FindAudio(name);
        uiSource.PlayOneShot(audio.clip);
        uiSource.volume = audio.volume; 
    }

    public void PlayEffectSound (string name)
    {
        var audio = FindAudio(name);
        effectSource.PlayOneShot(audio.clip);
        effectSource.volume = audio.volume;
    }

    public void PlayMusic(string name)
    {
        var audio = FindAudio(name);
        musicSource.clip = audio.clip;
        musicSource.volume = audio.volume;
        musicSource.Play();
    }
}
