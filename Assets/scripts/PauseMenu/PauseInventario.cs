using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInventario : MonoBehaviour
{
    public bool GameIsPause = false;
    public GameObject inventoryUI;
    public GameObject buttonInventory;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetButtonDown("Inventory")){
        //     if(GameIsPause && player.pausedGame){
        //         Resume();

        //     }else if(!GameIsPause && !player.pausedGame){
        //         ActivyInventory();
        //     }
        // }
    }

    public void Resume(){
        inventoryUI.SetActive(false);
        GameIsPause = false;
    }

    public void ActivyInventory(){
        inventoryUI.SetActive(true);
        GameIsPause = true;
    }

}


