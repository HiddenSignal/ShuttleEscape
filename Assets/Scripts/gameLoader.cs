using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class gameLoader : MonoBehaviour {

    public GameObject gameManager;
    

	// Use this for initialization
    void Awake()
    {

        //Enables the Debug Log
        PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        userAuth();

        ((PlayGamesPlatform)Social.Active).SetDefaultLeaderboardForUI("CgkIwLGKgaIdEAIQAA");


    }

    public bool Authenticated
    {
        get
        {
            return Social.Active.localUser.authenticated;
        }
    }

    public void userAuth()
    {
        if (!Social.localUser.authenticated)
        {
            // Authenticate
            Social.localUser.Authenticate((bool success) =>
            {
            });
        }
    }
}
