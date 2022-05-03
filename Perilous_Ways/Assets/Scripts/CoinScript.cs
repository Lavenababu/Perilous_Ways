using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private AudioSource collectCoin;
     public void OnTriggerEnter2D(Collider2D collision)
    {
        collectCoin.Play();
        GameController.moneyAmount += 1;
        Destroy(gameObject);
    }
}
