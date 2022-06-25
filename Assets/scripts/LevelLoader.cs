using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour{
    
    public Player scriptPlayer;

    public Animator transition;

    public float transitionTime = 100f; 

    void Start(){
  
    }
    void Update(){
        if(scriptPlayer.levelNext == true){
            LoadNextLevel();
            scriptPlayer.levelNext = false;
        }
        if(scriptPlayer.levelBack == true){
            LoadBackLevel();
            scriptPlayer.levelBack = false;
        }


	}

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadBackLevel()
    {
        StartCoroutine(LoadLevelBack(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelIndex);
        scriptPlayer.respawnPoint = scriptPlayer.transform.position;
        yield return new WaitForSeconds(transitionTime);
    }
    
    IEnumerator LoadLevelBack(int levelIndex)
    {
        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelIndex);
        scriptPlayer.respawnPoint = scriptPlayer.transform.position;
        yield return new WaitForSeconds(transitionTime);
    }
}

