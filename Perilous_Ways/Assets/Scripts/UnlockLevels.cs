using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockLevels : MonoBehaviour
{
    // public static bool unlocked2;
    // public static bool unlocked3;
    // public static bool unlocked4;
    public static int moneyAmount;
    // [SerializeField] private Level level2;
    // [SerializeField] private Level level3;
    // [SerializeField] private Level level4;

    // public Image unlockImage;
    public Animator transition;
    public float transitionTime = 1f;

    private void Update()
    {
        updateLevelImage();
    }
    private void updateLevelImage()
    {
        // if(unlocked2==false)
        // {
        //     level2.Locked();
        // }
        // else
        // {
        //     level2.Unlocked();
        // }


        // if(unlocked3==false)
        // {
        //     level3.Locked();
        // }
        // else
        // {
        //     level3.Unlocked();
        // }


        // if(unlocked4==false)
        // {
        //     level4.Locked();
        // }
        // else
        // {
        //     level4.Unlocked();
        // }
    }

    public void LoadSelectLevel(int sceneID)
    {
        // if(unlocked3 == true || unlocked4 == true)  //unlocked2 == true || 
        {
            PlayerPrefs.SetInt("MoneyAmount",moneyAmount);
            StartCoroutine(LoadLevel(sceneID));
        }
    }
    IEnumerator LoadLevel (int levelIndex)
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
