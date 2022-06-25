using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class dialogueMananger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _story;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private TextMeshProUGUI _btnContinue;

    [SerializeField]
    private GameObject _dialogueBox;

    //Tentar
     public UnityEvent _PressedEnter;

    private int _count=0;
    private dialogue _dialogueNow;
    public InteractInput interactButton;

    public void Update(){
        if(interactButton.InteractEnter){
            _PressedEnter.Invoke();
        }
    }

    public void Begin(dialogue dialogue)
    {   
        _count=0;
        _dialogueNow=dialogue;
        NextPhrase();
    }

    public void NextPhrase(){
        if(_dialogueNow==null)
            return;

        if(_count == _dialogueNow.GetPhrases().Length){
            _dialogueBox.gameObject.SetActive(false);
            _dialogueNow=null;
            _count=0;
            return;
        }

        _story.text= _dialogueNow.GetTitleBox();
        _text.text=_dialogueNow.GetPhrases()[_count].GetPhrase();
        _btnContinue.text=_dialogueNow.GetPhrases()[_count].GetButtonContinue();
        _dialogueBox.gameObject.SetActive(true);
        _count++;
    }
    
}
