using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {



	void FixedUpdate () {


        transform.Translate(Vector3.up * Time.deltaTime * 3.2f);


        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                transform.Rotate(0, 0, 4);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                transform.Rotate(0, 0, -4);
            }
        }


        if (Input.GetKey("left"))
            transform.Rotate(0, 0, 4);

        if (Input.GetKey("right"))
            transform.Rotate(0, 0, -4);
	}
 

}