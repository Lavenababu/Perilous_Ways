using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static int moneyAmount;
    public Animator transition;
    public float transitionTime = 1f;
    //public Button[] levelButtons;

void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
        
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadSelectLevel(int sceneID)
    {
        PlayerPrefs.SetInt("MoneyAmount",moneyAmount);
        StartCoroutine(LoadLevel(sceneID));
    }

    IEnumerator LoadLevel (int levelIndex)
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
