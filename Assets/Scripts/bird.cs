using UnityEngine;
using System.Collections;

public class bird : MonoBehaviour {

	int state = 1;
	Transform birdTransform;

	void Awake()
	{
		birdTransform = transform;
		flip ();
		
	}
	
	// Update is called once per frame
	void Update () {
	
		//Sets a state for the direction of the bird.
		if (birdTransform.position.x >= 1){
			state = 1;
		}
		if (birdTransform.position.x <= -1){
			state = -1;
		}



		if (state == 1){
			birdTransform.Translate (Vector3.left * Time.deltaTime);
			flip ();
		}

		if (state == -1){
			birdTransform.Translate (Vector3.right * Time.deltaTime);
			flip ();
		}

	
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
		Vector3 theScale = birdTransform.localScale;
		if (state == -1){
			theScale.x = -0.4f;}
		if (state == 1){
			theScale.x = 0.4f;}

		transform.localScale = theScale;
	}

}
