using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class startDialogue : MonoBehaviour
{
    [SerializeField]
    private dialogueMananger _mananger;
    [SerializeField]
    private dialogue _dialogue;

   public CircleCollider2D _circleCollider;

    private void Awake(){
       _circleCollider= GetComponent<CircleCollider2D>();

    }
    public void Begin(){
        if(_mananger==null)
            return;

        _mananger.Begin(_dialogue);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag.Equals("Player")){
            Begin();
        }
    }
}
