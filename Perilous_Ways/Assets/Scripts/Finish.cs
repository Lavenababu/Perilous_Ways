using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    int moneyAmount;
    [SerializeField] private GameController gameController;
    [SerializeField] GameObject gameOverPanel;
    public AudioSource finalAudio;
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Invoke("CompleteGame",1f);
            // CompleteGame();
        }
    }

    private void CompleteGame()
    {
        finalAudio.Play();
        gameController.getCoins();
        // SceneManager.LoadScene(1);  

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
