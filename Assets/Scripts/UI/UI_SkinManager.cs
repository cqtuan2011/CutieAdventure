using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkinManager : MonoBehaviour
{
    [SerializeField] private int currentSelectedCharacter;

    [SerializeField] private Sprite[] character;

    [SerializeField] private Animator frameAnim;

    private Image skinDisplay;
    

    private void Awake()
    {
        skinDisplay = GetComponent<Image>();
    }

    private void Start()
    {
        currentSelectedCharacter = PlayerPrefs.GetInt("currentSelectedCharacter");

        UpdateCharacterImage(currentSelectedCharacter);
    }

    public void PreviousButtonClick()
    {
        currentSelectedCharacter--;
        TriggerFrameAnimation();

        if (currentSelectedCharacter < 0)
        {
            currentSelectedCharacter = character.Length - 1;
        }
        UpdateCharacterImage(currentSelectedCharacter);
    }

    public void NextButtonClick()
    {
        currentSelectedCharacter++;
        TriggerFrameAnimation();

        if (currentSelectedCharacter > character.Length - 1)
        {
            currentSelectedCharacter = 0;
        }
        UpdateCharacterImage(currentSelectedCharacter);
    }

    private void UpdateCharacterImage(int currentSelectedCharacter)
    {
        skinDisplay.sprite = character[currentSelectedCharacter];
        PlayerPrefs.SetInt("currentSelectedCharacter", currentSelectedCharacter);
    }

    private void TriggerFrameAnimation()
    {
        frameAnim.Play("Frame");
    }
}
