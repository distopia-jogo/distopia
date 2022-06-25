using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void LoadingLevel(string nameScene){
        //operation.progress
        StartCoroutine(LoadAsynchronously(nameScene));
    }

    IEnumerator LoadAsynchronously(string nameScene){
        AsyncOperation operation= SceneManager.LoadSceneAsync(nameScene);

        loadingScreen.SetActive(true);
        while(operation.isDone==false){
            float progress=Mathf.Clamp01(operation.progress/.9f);
            slider.value=progress;
            yield return null;
        }

    }
}
