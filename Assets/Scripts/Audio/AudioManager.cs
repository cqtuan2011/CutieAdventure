using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource effectSource, uiSource, musicSource;

    [SerializeField] private List<Audio> audios;

    [SerializeField] private AudioClip[] bgms;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

        } else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();

        source.playOnAwake = false;

        switch (scene.name)
        {
            case "1":
                source.clip = bgms[0];
                break;
            case "2":
                source.clip = bgms[1];
                break;
            case "3":
                source.clip = bgms[2];
                break;
            case "4":
                source.clip = bgms[3];
                break;
            case "5":
                source.clip = bgms[4];
                break;
            default:
                source.clip = bgms[5];
                break;
        }

        if (source.clip != musicSource.clip)
        {
            musicSource.enabled = false;
            musicSource.clip = source.clip;
            musicSource.enabled = true;
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
