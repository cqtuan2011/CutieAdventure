using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinSelect : MonoBehaviour
{
    public enum Player { NinjaFrog, VirtualGuy, PinkMan, MaskDude }
    public Player playerSelected;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playerController;
    public Sprite[] playerSprite;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        var i = PlayerPrefs.GetInt("currentSelectedCharacter");

        spriteRenderer.sprite = playerSprite[i];
        anim.runtimeAnimatorController = playerController[i];

        //switch(playerSelected)
        //{
        //    case Player.NinjaFrog:
        //        spriteRenderer.sprite = playerSprite[1];
        //        anim.runtimeAnimatorController = playerController[1];
        //        break;

        //    case Player.VirtualGuy:
        //        spriteRenderer.sprite = playerSprite[3];
        //        anim.runtimeAnimatorController = playerController[3];
        //        break;

        //    case Player.PinkMan:
        //        spriteRenderer.sprite = playerSprite[2];
        //        anim.runtimeAnimatorController = playerController[2];
        //        break;

        //    case Player.MaskDude:
        //        spriteRenderer.sprite = playerSprite[0];
        //        anim.runtimeAnimatorController = playerController[0];
        //        break;

        //    default:
        //        break;
        //}
    }
}
