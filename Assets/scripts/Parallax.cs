using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length;
    private float StartPosition;
    public Transform cam;
    public float ParallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition=transform.position.x;
        length=GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        // float RestartPosition=cam.transform.position.x*(1-ParallaxEffect); 

        // float Distance=cam.transform.position.x*ParallaxEffect;

        // transform.position=new Vector3(StartPosition+Distance, transform.position.y, transform.position.z); 

        // if(RestartPosition>StartPosition+length){
        //     StartPosition+=length;
        // }
        // if(RestartPosition<StartPosition-length){
        //     StartPosition-=length;
        // }

        float temp = (cam.transform.position.x * (1 - ParallaxEffect));

        float dist = (cam.transform.position.x * ParallaxEffect);

        transform.position = new Vector3(StartPosition + dist, transform.position.y, transform.position.z);

        if(temp > StartPosition + length) StartPosition += length;
        else if (temp < StartPosition - length) StartPosition -= length;

        
    }
}
