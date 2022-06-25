using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    // public Transform cameraHigh;
    public float dampTime= 0.4f;
    private Vector3 cameraPos;
    private Vector3 velocity= Vector3.zero;

    void Update(){
        cameraPos=new Vector3(player.position.x, -3.537991f, -10f);
        transform.position=Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, dampTime);
    }

    // private void FixedUpdate(){
    //     transform.position=Vector2.Lerp(transform.position, player.position, 0.5f);
    // } 
    
}









