using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class shuttle : MonoBehaviour {

	
	private float score = 0;                            //Players score for each run, starts at 0
	private float startDistance;                        //Players starting Y position
	public Transform space;                             //Transform coordinates of the space sprite
	private string sDistance = "Distance Traveled";     //Stores the string for the gui display
	private static long finalScore = 0;                 //The high score starts at 0, it is static so it doesn't get reset to 0

    private gameStuff gameStuffScript;

	private float timer2;                               //Timer for delaying instatiation of the background
	public Text highScore;                              //Text storage for the GUI display

    Vector2 shuttlePos;
    Quaternion shuttleRot;

	// Use this for initialization
	void Start () { 

        //Sets the start distance to 0 for the purposes of proper score display
        gameStuffScript = GameObject.Find("Game Manager").GetComponent<gameStuff>();

        shuttlePos = transform.position;
        shuttleRot = transform.rotation;

        
		startDistance = transform.position.y;
	}
 
		
	// Update is called once per frame
	void FixedUpdate () {				

        //Rounds the score to a readable decimal position, in this case .##
		score =  Mathf.Round((transform.position.y) * 100.0f) / 100.0f;
        	

        //If the player manages to reach the base of the level (the grass), or fly too far off to the side,
        //the level will reset
        if (transform.position.y < -20 || transform.position.x <= -1.8f || transform.position.x >= 1.8f)
            restart();				
	
	}

    //void OnGUI() {
    //    //Displays the score on the bottom of the screen
    //    highScore.text = (sDistance + ": " + score +  "" +
    //        "                            Your top score this session: " + finalScore);
    //}

    //Trigger that checks if the player has collided with anything
	void OnTriggerEnter2D(Collider2D coll) {

        //Checks if the object the player collided with is tagged as an obstacle
		if (coll.gameObject.tag == "obstacle")
		{
            //Checks if the players current score is higher than a previous high score in this play session
            //before restarting the level
			if (score > finalScore)
			{
                //If the players current run has a score higher than a previous run, the current
                //run score becomes the high score
				finalScore = (long)score;

                //Runs the function to send the score to the leaderboard
				getHiScore();
			}

            //Restarts the level after a collision is detected
			restart ();
		}
	} 

    //Reloads the level
	public void restart()
	{
        transform.position = shuttlePos;
        transform.rotation = shuttleRot;
        gameStuffScript.gameStart();
	}

    //Function that will send the high score to the leaderboard
	public void getHiScore()
	{
        //Checks if the user has a google account, and if it has successfully authenticated
		if( Social.localUser.authenticated)
		{
            //Sends the high score to the leaderboard, whether it succeeds or fails, 
            //no result needs to be reported
			Social.ReportScore(finalScore, "CgkIwLGKgaIdEAIQAA", (bool success) => {
			
			});
		}	
	}	
}
