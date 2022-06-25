using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{

    public Transform player;

    private void FixedUpdate(){
        transform.position=Vector2.Lerp(transform.position, player.position, 0.01f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
