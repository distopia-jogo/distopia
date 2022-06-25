using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InteracterDrawer : MonoBehaviour
{
    public GameObject drawerOpened, paper;
    public float transitionTime = 100f;

    // Start is called before the first frame update
    void Start()
    {
        drawerOpened.SetActive(false);
        
    }

    // Update is called once per frame
    public void Open()
    {
        drawerOpened.SetActive(true); 
        paper.SetActive(false);  
    }

    public void Close(){
        drawerOpened.SetActive(false);
    }

    public void OpenPaper()
    {
        paper.SetActive(true);
    }

   
}
