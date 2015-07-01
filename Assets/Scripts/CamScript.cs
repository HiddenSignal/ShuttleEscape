using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour
{
	//Sets the state of the camera
	private Transform player; 
	private Vector3 relCameraPos;
    public static int waitCam = 0;

		// Use this for initialization
		void Start ()
		{
            
		}

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            relCameraPos = player.position - transform.position;
        }
	
		// Update is called once per frame
		void FixedUpdate ()
		{
			transform.position = new Vector3 (0, player.position.y-relCameraPos.y, player.position.z-relCameraPos.z);

		}


	
	
}
