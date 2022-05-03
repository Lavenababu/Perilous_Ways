using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int moneyAmount;
    public Text moneyAmountText;
    public Button coinButton2;
    public Button coinButton3;
    public Button coinButton4;
    public Animator transition;
    public float transitionTime = 1f;

    int unlock2;
    int unlock3;
    int unlock4;
    [SerializeField] private Level levelno2;
    [SerializeField] private Level levelno3;
    [SerializeField] private Level levelno4;

    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    void Update()
    {
        moneyAmountText.text =  moneyAmount.ToString();

        unlock2 = PlayerPrefs.GetInt("unlock2");
        unlock3 = PlayerPrefs.GetInt("unlock3");
        unlock4 = PlayerPrefs.GetInt("unlock4");


        if (moneyAmount >= 250 && unlock2==0)
            coinButton2.interactable = true;
        else
            coinButton2.interactable = false;

        if (moneyAmount >= 700 && unlock3==0)
            coinButton3.interactable = true;
        else
            coinButton3.interactable = false;
        
        if (moneyAmount >= 1500 && unlock4==0)
            coinButton4.interactable = true;
        else
            coinButton4.interactable = false;

        updateLevelImage();

    }

    public void level2()
    {
        moneyAmount -= 250;
        PlayerPrefs.SetInt("unlock2",1);
        coinButton2.gameObject.SetActive(false);
    }
    public void level3()
    {
        moneyAmount -= 700;
        PlayerPrefs.SetInt("unlock3",1);
        coinButton3.gameObject.SetActive(false);
    }
    public void level4()
    {
        moneyAmount -= 1500;
        PlayerPrefs.SetInt("unlock4",1);
        coinButton4.gameObject.SetActive(false);
    }
     private void updateLevelImage()
    {
        if(unlock2==0)
        {
            levelno2.Locked();
        }
        else
        {
            levelno2.Unlocked();
        }

        if(unlock3==0)
        {
            levelno3.Locked();
        }
        else
        {
            levelno3.Unlocked();
        }

        if(unlock4==0)
        {
            levelno4.Locked();
        }
        else
        {
            levelno4.Unlocked();
        }
    }
    public void LoadSelectLevel(int sceneID)
    {
        if(unlock2 == 1 || unlock3 == 1 || unlock4 == 1)
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
