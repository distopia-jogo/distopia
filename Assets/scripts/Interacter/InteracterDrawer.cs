using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InteracterDrawer : MonoBehaviour
{
    public GameObject drawerOpened;
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
    }

    public void Close(){
        drawerOpened.SetActive(false);
    }

   
}
