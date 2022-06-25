using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorCode : MonoBehaviour
{
    public InputField password;
    public GameObject codeScene;
    public Player player;


    void Start()
    {
        codeScene.SetActive(false);
    }

    public void Open()
    {
        player.pausedGame = true;
        codeScene.SetActive(true);
         
    }
    public void Close()
    {
        player.pausedGame = false;
        codeScene.SetActive(false);
        
    }

    public void verifyPass()
    {
        if(string.IsNullOrEmpty(password.text))
        {
            
            password.text = "Senha vazia";
        }
        else
        {
            if(password.text == "atrebor")
            {
                
                password.text = "Senha correta";
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
              
                password.text = "Senha incorreta";
            }
        }
    
    }
}
