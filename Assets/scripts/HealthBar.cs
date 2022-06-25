using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{


    public Sprite FULLHP, LESS5, LESS4, LESS3, LESS2, LESS1, EMPTYHP;

    public Player playerScript;
    public Image imageHealthBar;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LifeBar(playerScript.hitQuantity);
    }


    void LifeBar(int lifeQuantity)
    {

        if (lifeQuantity == 0)
        {
            imageHealthBar.sprite = FULLHP;
        }
        if (lifeQuantity == 1)
        {
            imageHealthBar.sprite = LESS1;
        }
        if (lifeQuantity == 2)
        {
            imageHealthBar.sprite = LESS2;
        }
        if (lifeQuantity == 3)
        {
            imageHealthBar.sprite = LESS3;
        }
         if (lifeQuantity == 4)
        {
            imageHealthBar.sprite = LESS4;
        }
        if (lifeQuantity == 5)
        {
            imageHealthBar.sprite = LESS5;
        }
        if (lifeQuantity == 6)
        {
            imageHealthBar.sprite = EMPTYHP;
        }
       








    }
}
