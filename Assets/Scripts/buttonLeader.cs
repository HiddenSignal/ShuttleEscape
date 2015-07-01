using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class buttonLeader : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void isPressed(bool clicked)
	{
		if (clicked == true)
			((PlayGamesPlatform) Social.Active).ShowLeaderboardUI("CgkIwLGKgaIdEAIQAA");		
	}

}
