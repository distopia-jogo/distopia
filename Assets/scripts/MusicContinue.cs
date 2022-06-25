using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicContinue : MonoBehaviour
{
    private static MusicContinue instance;
    public AudioSource BGM;
    public AudioClip menu;
    public AudioClip game01;
    public AudioClip game02;
    public AudioClip game03;
    public AudioClip game04;
    public AudioClip game05;
    public AudioClip gameOver;

    void Awake()
    {
        if(instance==null){

            instance = this;
            DontDestroyOnLoad(instance);

        }
        else
        {
        Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4){
            if (BGM.clip != menu){
                changeBGM(menu);
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7){
            if (BGM.clip != game01){
                changeBGM(game01);
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 8 || SceneManager.GetActiveScene().buildIndex == 9){
            if (BGM.clip != game02){
                changeBGM(game02);
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 10){
            if (BGM.clip != game03){
                changeBGM(game03);
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 11){
            if (BGM.clip != game04){
                changeBGM(game04);
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 12 || SceneManager.GetActiveScene().buildIndex == 13){
            if (BGM.clip != game05){
                changeBGM(game05);
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 5){
            if (BGM.clip != gameOver){
                changeBGM(gameOver);
            }
        }

    }

    public void changeBGM(AudioClip music){
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
     }
}
 