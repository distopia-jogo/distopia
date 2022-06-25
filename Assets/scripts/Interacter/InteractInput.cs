using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
 
    //InteractPlayer
	public bool IsInteract {get; set;}
    public bool IsInteractExit {get; set;}
    public bool InteractEnter {get; set;}
  
    void Update()
    {
        if(Input.GetButtonDown("Interact")){
            IsInteract=true;	
        }else{
            IsInteract=false;
        }

        if(Input.GetButtonDown("Exit")){
            IsInteractExit=true;
        }else{
            IsInteractExit=false;
        }

        if(Input.GetButtonDown("Submit")){
            InteractEnter=true;	
        }else{
            InteractEnter=false;
        }   
    }
        
}

