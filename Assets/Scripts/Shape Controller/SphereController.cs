using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour {

    public float maxRotationalSpeed = 500.0f;

    private void Awake()
    {
        gameObject.rigidbody.maxAngularVelocity = maxRotationalSpeed;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () 
    {

        //Quaternion newRotation = Quaternion.Euler(gameObject.rigidbody.rotation.eulerAngles + new Vector3(0.0f, 0.0f, maxRotationalSpeed) * Time.deltaTime);

        //gameObject.rigidbody.MoveRotation(newRotation);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.rigidbody.AddForce(0.0f, 100.0f, 0.0f, ForceMode.Force);
        }

	}

    public override void FormUpdate()
    {
        gameObject.rigidbody.AddRelativeTorque(0.0f, 0.0f, maxRotationalSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, ForceMode.Acceleration);
    }
}
