using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class dialogue 
{
    [SerializeField]
    private textDialogue[] _phrases;

    private string _titleBox;

    public textDialogue[] GetPhrases(){
        return _phrases;
    }

    public string GetTitleBox(){
        return _titleBox;
    }
    
}
