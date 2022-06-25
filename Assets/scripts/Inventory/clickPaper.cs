using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPaper : MonoBehaviour
{
    public GameObject paperClick;

    void Start()
    {
        paperClick.SetActive(false);
    }

    public void PaperOn()
    {
        paperClick.SetActive(true);
    }
}
