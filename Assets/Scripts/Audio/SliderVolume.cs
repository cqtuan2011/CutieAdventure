using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        soundSlider.onValueChanged.AddListener(value => AudioManager.Instance.ChangeSoundVolume(value));
        musicSlider.onValueChanged.AddListener(value => AudioManager.Instance.ChangeMusicVolume(value));
    }

    private void Update()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
}
