using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    public Animator animator1;

    //3 lives - 3 images (0,1,2)
    //2 lives - 2 images (0,1,[2])
    //1 live - 1 image (0,[1],[2])
    //0 lives - 0 images ([0,1,2]) - LOSE GAME

    public void LoseLife()
    {
        //Decrease the value of livesRemaining
        livesRemaining--;
        Debug.Log("Funfo");

        animator1.SetBool("isDashing", false);

        //Hide one of the life images
        lives[livesRemaining].enabled = false;
        
        //If we run out of lifes we lose the game
        if(livesRemaining==0)
        {
           SceneManager.LoadScene("gameover");
        }
    }
}
