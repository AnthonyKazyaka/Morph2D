using UnityEngine;
using System.Collections;

public class SphereController : ShapeController {

    public float maxRotationalSpeed = 500.0f;

    public GameObject Sphere { get { return _shapeGameObject; } set { _shapeGameObject = value; } }

    public void InitializeForm(Transform transform)
    {


        //gameObject.rigidbody.maxAngularVelocity = maxRotationalSpeed;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () 
    {

        //Quaternion newRotation = Quaternion.Euler(gameObject.rigidbody.rotation.eulerAngles + new Vector3(0.0f, 0.0f, maxRotationalSpeed) * Time.deltaTime);

        //gameObject.rigidbody.MoveRotation(newRotation);
        

	}

    public override void FormUpdate()
    {
        //gameObject.rigidbody.AddRelativeTorque(0.0f, 0.0f, maxRotationalSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, ForceMode.Acceleration);
    }
}
