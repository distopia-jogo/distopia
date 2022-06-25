using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsMenu : MonoBehaviour
{
    public void StartCredits(){
        SceneManager.LoadScene("creditos");
    }

    public void StartGame()
    {     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void StartConfiguration()
    {
        SceneManager.LoadScene("configuration");
    }

    public void ComeBack()
    {
        SceneManager.LoadScene("login");
    }

    public void ComeBack2()
    {
        SceneManager.LoadScene("menu");
    }

}
