using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_SkinManager : MonoBehaviour
{
    [SerializeField] private int currentSelectedCharacter;

    [SerializeField] private Sprite[] character;

    [SerializeField] private Animator frameAnim;

    [SerializeField] private TextMeshProUGUI characterName;

    private Image skinDisplay;

    private void Awake()
    {
        skinDisplay = GetComponent<Image>();
    }

    private void Start()
    {
        currentSelectedCharacter = PlayerPrefs.GetInt("currentSelectedCharacter");

        UpdateCharacter(currentSelectedCharacter);
    }

    public void PreviousButtonClick()
    {
        currentSelectedCharacter--;
        TriggerFrameAnimation();

        if (currentSelectedCharacter < 0)
        {
            currentSelectedCharacter = character.Length - 1;
        }
        UpdateCharacter(currentSelectedCharacter);
    }

    public void NextButtonClick()
    {
        currentSelectedCharacter++;
        TriggerFrameAnimation();

        if (currentSelectedCharacter > character.Length - 1)
        {
            currentSelectedCharacter = 0;
        }
        UpdateCharacter(currentSelectedCharacter);
    }

    private void UpdateCharacter(int currentSelectedCharacter)
    {
        skinDisplay.sprite = character[currentSelectedCharacter];
        UpdateCharacterName();
        PlayerPrefs.SetInt("currentSelectedCharacter", currentSelectedCharacter);
    }

    private void UpdateCharacterName()
    {
        switch (currentSelectedCharacter)
        {
            case 0:
                characterName.text = "Mask Dude";
                break;
            case 1:
                characterName.text = "Ninja Frog";
                break;
            case 2:
                characterName.text = "Pink Man";
                break;
            case 3:
                characterName.text = "Virtual Guy";
                break;
            default:
                break;
        }
    }

    private void TriggerFrameAnimation()
    {
        frameAnim.Play("Frame");
    }
}
