using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_BottomUp : MonoBehaviour
{
    [SerializeField] private List<RectTransform> buttons;

    [SerializeField] private float delayStart = 0.5f;
    [SerializeField] private float delayDisplay = 0.1f;
    [SerializeField] private float posY = -90f;

    private void Start()
    {
        StartCoroutine(BottomUpAnimation(delayStart, delayDisplay));
    }

    IEnumerator BottomUpAnimation(float delayStart, float delayDisplay)
    {
        yield return new WaitForSeconds(delayStart);

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].DOAnchorPosY(posY, 0.6f).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(delayDisplay);
        }
    }
}
