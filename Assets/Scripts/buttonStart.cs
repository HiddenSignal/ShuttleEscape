using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonStart : MonoBehaviour {

    private gameStuff gameStuffScript;

    void Awake()
    {
        gameStuffScript = GetComponentInParent<gameStuff>();
        
    }

	public void isPressed(bool clicked)
	{
        if (clicked == true)
        {
            gameStuffScript.gameStart();
          
        }
            
		
		
	}
}
