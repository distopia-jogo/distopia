using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurricane1 : MonoBehaviour
{

    //Freeze rotation Z


    private SpriteRenderer furacaoAnimated;   
    public float velocity = 0.01f;
    public float distanceFirst = -0.5f;
    public float distanceLast = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        furacaoAnimated = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = new Vector3(transform.position.x + velocity, transform.position.y, transform.position.z);

        //Change velocity
        //Walk to back
        if(transform.position.x > distanceLast){
            velocity= velocity*-1;
            furacaoAnimated.flipX=true;
        }
        //Walk to front
        if(transform.position.x < distanceFirst){
            velocity=velocity*-1;
            furacaoAnimated.flipX=false;
        }
        



    }
}
