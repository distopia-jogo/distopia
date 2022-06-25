using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public GameObject Player;
    // public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Posição x
        float xPosition=Player.transform.position.x*0.8f;
        transform.position=new Vector3(xPosition, transform.position.y,transform.position.z);
    }
}
