using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractChest : MonoBehaviour
{
     public SpriteRenderer imageDrawer;

    public Player _player;

    public InteractInput interactInput;

    [SerializeField]
    public bool _mayCheckInventory;

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
                        
                _player.addingItem("history");
                _player.InventoryPatch();       
            }
            if(interactInput.IsInteractExit){
                _PressedButtonQ.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _mayExecute=true;
        imageDrawer.color = new Color(255f/255f, 183f/255f, 0f/255f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _mayExecute=false;
        imageDrawer.color = Color.white;
    }
}
