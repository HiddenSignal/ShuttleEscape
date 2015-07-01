using UnityEngine;
using System.Collections;

public class asteroid : MonoBehaviour {

	Transform astrTrans;

	// Use this for initialization
	void Start () {
		astrTrans = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		astrTrans.Rotate(0, 0, 1);
		
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
}
