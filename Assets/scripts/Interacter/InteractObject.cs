using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class InteractObject : MonoBehaviour
{
    public Player player;

    [SerializeField]
    public string _name;

    [SerializeField]
    private AudioClip _sound;

    public CircleCollider2D _circleCollider;
    private void Awake(){
       _circleCollider= GetComponent<CircleCollider2D>();

    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.tag.Equals("Player")){
            var player= collision.gameObject.GetComponent<Player>();
            
            player.addingItem(_name);
            player.InventoryPatch();

            if(_sound)
                AudioSource.PlayClipAtPoint(_sound, transform.position);
            
            Destroy(this.gameObject);
        }

    }

}
