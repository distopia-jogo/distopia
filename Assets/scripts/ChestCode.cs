using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCode : MonoBehaviour
{
   
   public GameObject chestScene, paper1, paper2;
   
   void Start()
    {
        chestScene.SetActive(false);
    }

    public void Open()
    {
        chestScene.SetActive(true);
        paper2.SetActive(false);
    }
    public void Close()
    {
        chestScene.SetActive(false);
    }

    public void nextPaper()
    {
        paper1.SetActive(false);
        paper2.SetActive(true);
    }

    public void PreviousPaper()
    {
        paper1.SetActive(true);
        paper2.SetActive(false);
    }
}
