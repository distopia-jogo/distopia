using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public List<string> _ItemsInventory= new List<string>();

    public static GameController Instance;
    
    void Start()
    {
        Instance = this;
    }

    public void addingItem(string nameItem){
		
		if(!existItem(nameItem))
		{
			_ItemsInventory.Add(nameItem);
		}

	}
	public bool existItem(string nameItem){
		return _ItemsInventory.Contains(nameItem);
	}


}
