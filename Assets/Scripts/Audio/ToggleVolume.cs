using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVolume : MonoBehaviour
{
    [SerializeField] private Sprite[] volumeControl; // [0] is on , [1] is mute 

    private Image img;
    public enum ToggleType { Sound, Music}
    
    public ToggleType type;

    private void Awake()
    {
        img = GetComponent<Image>();    
    }

    private void Start()
    {
        
    }
    public void Toggle()
    {
        OnClickButton();
        switch (type)
        {
            case ToggleType.Sound:
                AudioManager.Instance.ToggleSound();
                break;

            case ToggleType.Music:
                AudioManager.Instance.ToggleMusic();
                break;

            default:
                break;
        }
    }

    private void OnClickButton()
    {
        if (img.sprite == volumeControl[0])
        {
            img.sprite = volumeControl[1];
        } else
        {
            img.sprite = volumeControl[0];
        }
    }
}
