using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Audio_UIButtons : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] private string hoveringSoundName;
    [SerializeField] private string clickSoundName;
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.PlayUIEffectSound(clickSoundName);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayUIEffectSound(hoveringSoundName);
    }
}
