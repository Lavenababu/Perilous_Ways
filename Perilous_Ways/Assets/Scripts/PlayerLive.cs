using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLive : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Trap")){
            Die();
        }
    }
    public void Die(){

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    //To restart the Level from start after player death(inifinte life)

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
