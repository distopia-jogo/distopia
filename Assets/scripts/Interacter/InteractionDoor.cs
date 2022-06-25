using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InteractionDoor: MonoBehaviour
{
    public SpriteRenderer imageDoor;

    public Player _player;

    public InteractInput interactInput;

    public UnityEvent _PressedButtonE, _PressedButtonQ;

    public bool _mayExecute;

    // Update is called once per frame
    void Update()
    {
        //Ação para ser excutada quando o jogador estiver na área determinada
        if(_mayExecute){
            //Detecta o botão E para a interação
            if(interactInput.IsInteract)
            {      
                _PressedButtonE.Invoke();
            }
            if(interactInput.IsInteractExit)
            {
                _PressedButtonQ.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        _mayExecute=true;
        imageDoor.color = new Color(255f/255f, 183f/255f, 0f/255f);
    }

    private void OnTriggerExit2D(Collider2D collision){
        _mayExecute=false;
        imageDoor.color = Color.white;
    }
}
