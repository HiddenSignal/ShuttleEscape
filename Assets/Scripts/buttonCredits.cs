using UnityEngine;
using System.Collections;

public class buttonCredits : MonoBehaviour {

	public void isPressed(bool clicked)
	{
		if (clicked == true)
			Application.LoadLevel("Credits");
		
	}
}
