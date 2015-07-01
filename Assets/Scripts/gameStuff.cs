using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameStuff : MonoBehaviour {

    //Declare initial GameObjects
    GameObject shuttleMove;
    GameObject obstSpawn;
    GameObject shutExhaust;
    

    Canvas menu;

    SpriteRenderer tutorGO;
    flame shuttleFlame;
    obstacleSpawn obstaclesStart;
    shuttle shuttleScript;
    
    //gameLive will control when certain scripts get activated
    public bool gameLive = false;
    public bool menuIsUp = true;
    public bool isHit = false;

    //A half second delay between levels
    public float gameDelay = 0.5f;

    //Used for the gameLoader to spawn this game object for the first time


    void Awake()
    {        
        //Ensures the game manager doesn't get destroyed on level changes and loads
        DontDestroyOnLoad(this.gameObject);

        menu = GetComponentInChildren<Canvas>();
        menu.enabled = true;

        shuttleFlame = GameObject.Find("exhaust").GetComponent<flame>();
        shuttleFlame.enabled = false;

        tutorGO = GameObject.Find("tutor").GetComponentInChildren<SpriteRenderer>();
        tutorGO.enabled = false;

        obstaclesStart = GetComponentInChildren<obstacleSpawn>();
        obstaclesStart.enabled = false;

        shuttleMove = GameObject.Find("shuttle");
        shuttleScript = GameObject.Find("shuttle").GetComponent<shuttle>();
        

        
    }

    void Update()
    {
             
            //The first touch will remove the tutorial screen
            //and after a brief delay, change gameLive to true through the method
            // "gameStart"
            if (Input.GetMouseButton(0) && gameLive == false && menuIsUp == false)
            {
                tutorGO.enabled = false;
          
                
                Invoke("tutorialScreenDelay", gameDelay);

            }

            //Second touch will enable the proper scripts so the level can begin
            if (Input.GetMouseButton(0) && gameLive == true && menuIsUp == false)
            {
                startScripts();
            }

 

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                tutorGO.enabled = false;
                shuttleScript.restart();
                menu.enabled = true;
                obstaclesStart.enabled = false;
                
            }

            if (isHit == true)
            {
                tutorGO.enabled = false;
                obstaclesStart.enabled = false;  
                shuttleScript.restart();
                gameStart();
            }
    }


    void startScripts()
    {
        
        

        shuttleMove.GetComponent<playerMovement>().enabled = true;
        shuttleFlame.enabled = true;

        obstaclesStart.enabled = true;  
    }

    
    public void gameStart()
    {
        obstaclesStart.enabled = false;  
        shuttleFlame.enabled = false;
        shuttleMove.GetComponent<playerMovement>().enabled = false;
        tutorGO.enabled = true;

        menu.enabled = false;
        menuIsUp = false;
        gameLive = false;  
    }

    public void tutorialScreenDelay()
    {
        gameLive = true;
    }
 
}
