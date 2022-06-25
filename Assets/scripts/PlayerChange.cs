using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChange : MonoBehaviour
{

    public string player;

    public void Player1()
	{
		player = "Player1";
	}
	public void Player2()
	{
		player = "Player2";
	}

    public void StartGame()
    {
        if(player == "Player1")
        {
            SceneManager.LoadScene(13);
        }
        else if(player == "Player2")
        {
            SceneManager.LoadScene(15);
        }
        else
        {
            SceneManager.LoadScene(13);
        }

    }
}
