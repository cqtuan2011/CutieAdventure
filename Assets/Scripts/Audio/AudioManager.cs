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
        uiSource.volume = PlayerPrefs.GetFloat("SoundVolume");
    }

    public void PlayEffectSound (string name)
    {
        var audio = FindAudio(name);
        effectSource.PlayOneShot(audio.clip);
        effectSource.volume = PlayerPrefs.GetFloat("SoundVolume");
    }

    public void PlayMusic(string name)
    {
        var audio = FindAudio(name);
        musicSource.clip = audio.clip;
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        musicSource.Play();
    }

    public void ChangeSoundVolume(float value)
    {
        effectSource.volume = value;
        uiSource.volume = value;
        PlayerPrefs.SetFloat("SoundVolume", value);
    }

    public void ChangeMusicVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void ToggleSound()
    {
        //effectSource.mute = !effectSource.mute;
        //uiSource.mute = !uiSource.mute;
        if (effectSource.volume > 0 && uiSource.volume > 0)
        {
            effectSource.volume = 0;
            uiSource.volume = 0;
            PlayerPrefs.SetFloat("SoundVolume", 0);
        } else if (effectSource.volume == 0 && uiSource.volume == 0)
        {
            float volume = PlayerPrefs.GetFloat("SoundVolume");
            effectSource.volume = volume;
            uiSource.volume = volume;
        }
    }

    public void ToggleMusic()
    {
        //musicSource.mute = !musicSource.mute;

        if (musicSource.volume > 0)
        {
            musicSource.volume = 0;
            PlayerPrefs.SetFloat("MusicVolume", 0);
        }
        else if (musicSource.volume == 0)
        {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
