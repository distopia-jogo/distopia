using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed=0;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CloudSpeed();   
    }

    void CloudSpeed(){

        float newPositionY=Random.Range(5f, 8f); //altura mínima = 5 / altura máxima = 8
        transform.position=new Vector3(transform.position.x+speed, transform.position.y, transform.position.z);
        if(transform.position.x < Player.transform.position.x-30){
            transform.position=new Vector3(Player.transform.position.x+30, newPositionY, transform.position.z);
        }
    }
}
