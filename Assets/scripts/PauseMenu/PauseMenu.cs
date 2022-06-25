using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPause;
    public GameObject pauseMenuUI;
    public GameObject buttonPause;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Escape)){
        //     if(GameIsPause && player.pausedGame){
        //         Resume();

        //     }else if(!GameIsPause && !player.pausedGame){
        //         Pause();
        //     }
        // }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale= 1f;
        GameIsPause= false;
        player.pausedGame = false;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale= 0f;
        GameIsPause= true;
        player.pausedGame = true;
    }

    public void LoadMenu(){
        Time.timeScale= 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame(){
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
