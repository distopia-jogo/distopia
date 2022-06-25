using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Configuration : MonoBehaviour
{
    
    public Dropdown ddpResolution;
    public Dropdown ddpQuality;
    public Toggle tgWindow;
    public float volumeMaster;
    public Slider savedVolume;

    private List<string> resolutions = new List<string>();
    private List<string> quality = new List<string>();


    void Start()
    {
        Resolution[] arrResolution = Screen.resolutions;
        foreach (Resolution r in arrResolution)
        {
            resolutions.Add(string.Format("{0} X {1}", r.width, r.height));
        }
        ddpResolution.AddOptions(resolutions);
        ddpResolution.value = (resolutions.Count - 1);

        quality = QualitySettings.names.ToList<string>();
        ddpQuality.AddOptions(quality);
        ddpQuality.value = QualitySettings.GetQualityLevel(); // Get current Quality level index

        savedVolume.value=(AudioListener.volume);


    }

    public void SetWindowMode()
    {
        if(tgWindow.isOn) // Return if Toggle is checked
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

    public void SetResolution() 
    {
        string[] res = resolutions[ddpResolution.value].Split('X');
        int w = System.Convert.ToInt16(res[0].Trim());
        int h = System.Convert.ToInt16(res[1].Trim());
        Screen.SetResolution(w, h, Screen.fullScreen);
    }

    public void SetQuality() 
    {
        QualitySettings.SetQualityLevel(ddpQuality.value, true);
    }  

    public void VolumeMaster(float volume){
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;

    }
}
