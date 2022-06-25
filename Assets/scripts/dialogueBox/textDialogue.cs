using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class textDialogue
{
    [SerializeField]
    [TextArea(1, 4)]
    private string _phrase;


    [SerializeField]
    private string _btnContinue;

    public string GetPhrase(){
        return _phrase;
    }

    public string GetButtonContinue(){
        return _btnContinue;
    }
    
}
