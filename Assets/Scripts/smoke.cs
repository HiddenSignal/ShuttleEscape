using UnityEngine;
using System.Collections;

public class smoke : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Player";
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 0;

	}	


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
