using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class obstacleSpawn : MonoBehaviour
{
	
	public float spawnTime = 0.8f;		// The amount of time between each spawn.
	public float spawnDelay = 0f;		// The amount of time before spawning starts.
	
    //Declares the three obstacle types
    public GameObject bird;		        
    public GameObject ufo;
    public GameObject asteroid;

    //Total amount of objects that can be in the object pool
    public int pooledAmount = 5;

    //A list of game objects for each obstacle type
    List<GameObject> birds;
    List<GameObject> ufos;
    List<GameObject> asteroids;

    //The transform of the player
	Transform shutTransform;  

	void Start ()
	{		
        //Creates a new List of game objects for the three obstacles
        birds = new List<GameObject>();
        ufos = new List<GameObject>();
        asteroids = new List<GameObject>();

        //Populates the Lists with obstacles
        for (int i = 0; i < pooledAmount; i++)
        {
            //Instantiates 10 instances of each obstacle
            GameObject objUFO = (GameObject)Instantiate(ufo);
            GameObject objAsteroid = (GameObject)Instantiate(asteroid);
            GameObject objBird = (GameObject)Instantiate(bird);

            //Sets each obstacle to Inactive
            objBird.SetActive(false);
            objUFO.SetActive(false);
            objAsteroid.SetActive(false);

            //Adds the instantiated obstacles into their respective list
            ufos.Add(objUFO);
            asteroids.Add(objAsteroid);
            birds.Add(objBird);
        }

        //Finds the transform of the player shuttle
		shutTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //Invokes the Spawn() method immediately, with a one second delay (spawnTime)
        //between invokes	
        
	}
	
	public void Spawn()
	{
        //Activates an available bird from its object pool and places it 
        //3 units ahead of the player at a random X coordinate between -1 and 2
        for (int i = 0; i < birds.Count; i++)
        {
            if (shutTransform.position.y <= 10)
            {
                if (!birds[i].activeInHierarchy)
                {
                    birds[i].SetActive(true);
                    birds[i].transform.position = new Vector3(Random.Range(-1f, 2f), shutTransform.position.y + 3, shutTransform.position.z);
                    break;
                }
            }
        }

        //Once the player reaches a certain point (3 units up on the Y axis),
        //activates an available UFO from its object pool and places it 
        //3 units ahead of the player at a random X coordinate between -1 and 2
        for (int i = 0; i < ufos.Count; i++)
        {

            if (shutTransform.position.y >= 10)
            {
                if (!ufos[i].activeInHierarchy)
                {
                    ufos[i].SetActive(true);
                    ufos[i].transform.position = new Vector3(Random.Range(-1f, 2f), shutTransform.position.y + 3, shutTransform.position.z);
                    break;
                }
            }
        }

        //Once the player reaches a certain point (20 units up on the Y axis),
        //activates an available asteroid from its object pool and places it 
        //4.5 units ahead of the player at a random X coordinate between -1.2 and 2.2
        for (int i = 0; i < asteroids.Count; i++)
        {

            if (shutTransform.position.y >= 20)
            {
                if (!asteroids[i].activeInHierarchy)
                {
                    asteroids[i].SetActive(true);
                    asteroids[i].transform.position = new Vector3(Random.Range(-1.2f, 2.2f), shutTransform.position.y + 4.5f, shutTransform.position.z);
                    break;
                }
            }
        }
    }

    void OnEnable()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
      

    void OnDisable()
    {
        CancelInvoke("Spawn");
    }
     
}

   
