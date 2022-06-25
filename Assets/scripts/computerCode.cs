using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class computerCode : MonoBehaviour
{
    public GameObject computerOpened;
    public GameObject newScene;
    public GameObject oldScene;
    public InputField password;
    public Text resultPassword;
    public Player player;

    void Start()
    {
        computerOpened.SetActive(false);
        newScene.SetActive(false); 
    }

    public void Open()
    {
        player.pausedGame = true;
        computerOpened.SetActive(true);  
    }
    public void Close()
    {
        player.pausedGame = false;
        computerOpened.SetActive(false);
    }

    public void verifyPass()
    {
        if(string.IsNullOrEmpty(password.text))
        {
            resultPassword.color = Color.red;
            resultPassword.text = "Senha vazia";
            computerOpened.SetActive(true);
        }
        else
        {
            if(password.text == "icas")
            {
                resultPassword.color = Color.green;
                resultPassword.text = "Senha correta";
                oldScene.SetActive(false);  
                newComputerScene();
                
            }
            else
            {
                resultPassword.color = Color.red;
                resultPassword.text = "Senha incorreta";
                computerOpened.SetActive(true);
            }
        }
    
    }

    public void newComputerScene()
    {
        newScene.SetActive(true);  
    }
}