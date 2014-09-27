using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () 
    {
        gameObject.rigidbody.AddTorque(0.0f, 0.0f, 1000.0f * Input.GetAxis("Horizontal") * Time.deltaTime, ForceMode.Acceleration);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.rigidbody.AddForce(0.0f, 100.0f, 0.0f, ForceMode.Force);
        }
	}
}
