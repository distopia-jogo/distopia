using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    public float SpeedEnemy = 5;
    private Transform positionPlayer;
    // Start is called before the first frame update
    void Start()
    {   //Procurando e acessando o jogador 
        positionPlayer=GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(positionPlayer.gameObject != null){
            //Movimentando o Enemy e seguindo o player
            transform.position=Vector2.MoveTowards(transform.position, positionPlayer.position, SpeedEnemy*Time.deltaTime);
        }
    }
}
