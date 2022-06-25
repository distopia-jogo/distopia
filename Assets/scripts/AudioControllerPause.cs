using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControllerPause : MonoBehaviour
{

    public Slider savedVolume;
    public float volumeMaster;

    void Start()
    {
        savedVolume.value=(AudioListener.volume);
    }

    public void VolumeMaster(float volume){
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;

    }
}
