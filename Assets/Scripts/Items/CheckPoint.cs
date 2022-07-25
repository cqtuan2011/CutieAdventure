using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private CheckPointType checkPointType;
    
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("isTouched");

            switch (checkPointType)
            {
                case CheckPointType.StartPoint:
                    break;
                case CheckPointType.EndPoint:

                    AudioManager.Instance.PlayUIEffectSound("Win");

                    UIManager.Instance.Invoke("OpenWinMenu", 0.5f);

                    var newData = new LevelData();
                    newData.levelIndex = int.Parse(SceneLoader.Instance.GetSceneName());
                    newData.colectedStars = StarManager.Instance.starAmount;

                    LevelManager.Instance.UpdateLevelData(newData);

                    break;
            }
        }
    }

    private enum CheckPointType
    {
        StartPoint,
        EndPoint,
    }
}
