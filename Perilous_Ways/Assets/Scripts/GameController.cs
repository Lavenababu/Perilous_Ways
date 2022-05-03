using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text moneyText;
    public static int moneyAmount;
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }
    void Update()
    {
        moneyText.text = "Coins : " + moneyAmount.ToString();
    }
    public void gotoLevel(int SceneNumber)
    {
        PlayerPrefs.SetInt("MoneyAmount",moneyAmount);
        SceneManager.LoadScene(SceneNumber);
    }
    public void getCoins()
    {
        PlayerPrefs.SetInt("MoneyAmount",moneyAmount);
    }
}
