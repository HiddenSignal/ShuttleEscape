using UnityEngine;
using System.Collections;

public class ufo : MonoBehaviour {
	int state = 1;
	
	
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//Sets a state for the direction of the bird.
		if (transform.position.x >= 1){
			state = 1;
		}
		if (transform.position.x <= -1){
			state = -1;
		}

		if (state == 1){
			transform.Translate (Vector3.left * Time.deltaTime);
			flip ();
		}
		
		if (state == -1){
			transform.Translate (Vector3.right * Time.deltaTime);
			flip ();
		}	
		
	}
	
	void Awake()
	{
		
		flip ();
		
	}

    void OnEnable()
    {
        Invoke("Destroy", 5f);

    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
	void flip()
	{
		Vector3 theScale = transform.localScale;
		if (state == -1){
			theScale.x = -0.1f;}
		if (state == 1){
			theScale.x = 0.1f;}
		
		transform.localScale = theScale;
	}
	
	
	
	
}
