using UnityEngine;
using System.Collections;

public class flame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Player";
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 0;

		GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = true;
	}

    void OnDisable()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = false;
    }

    void OnEnable()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().enabled = true;
    }

}
