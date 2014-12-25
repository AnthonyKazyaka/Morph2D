using UnityEngine;
using System.Collections;

public class SphereController : ShapeController {

    public const float MaxRotationalSpeed = 10000.0f;

    private float _rotationalSpeedModifier = 1500.0f;
    public float RotationalSpeedModifier { get { return _rotationalSpeedModifier; } }

    public GameObject Sphere { get { return _shapeGameObject; } }

    protected override void InitializeForm(Transform playerTransform)
    {
        _shapeGameObject = GameManager.Instance.InstantiateShape(GameManager.Shapes.Sphere);
        _shapeGameObject.rigidbody.maxAngularVelocity = MaxRotationalSpeed;
        _shapeGameObject.transform.position = playerTransform.position;
    }

    public override void InitializeFormWithVelocity(Transform playerTransform, Vector3 velocity)
    {
        InitializeForm(playerTransform);

        SetShapeVelocity(velocity);
    }

    public override void DisableForm()
    {
        GameManager.Instance.DestroyShape(_shapeGameObject);
    }

    public override void FormUpdate()
    {
        //Correct implementation
        _shapeGameObject.rigidbody.AddRelativeTorque(0.0f, 0.0f, -RotationalSpeedModifier * Input.GetAxis("Horizontal") * Time.deltaTime, ForceMode.Acceleration);
        
        if (_shapeGameObject.rigidbody.angularVelocity.magnitude > MaxRotationalSpeed)
        {
            _shapeGameObject.rigidbody.angularVelocity = new Vector3(0, 0, -MaxRotationalSpeed);
        }
    }
}
