using UnityEngine;
using System.Collections;

public class CubeController : ShapeController {

    private float _forwardDashForce = 15.0f;
    public float ForwardDashForce { get { return _forwardDashForce; } private set { _forwardDashForce = value; } }

    public GameObject Cube { get { return _shapeGameObject; } }

    protected override void InitializeForm(Transform playerTransform)
    {
        _shapeGameObject = GameManager.Instance.InstantiateShape(GameManager.Shapes.Cube);
        _shapeGameObject.transform.position = playerTransform.position;
    }

    public override void InitializeFormWithVelocity(Transform playerTransform, Vector3 velocity)
    {
        InitializeForm(playerTransform);

        SetShapeVelocity(velocity);

        int directionModifier = (Input.GetAxis("Horizontal") >= 0) ? 1 : -1;
        _shapeGameObject.rigidbody.AddForce((Vector3.right) * ForwardDashForce * directionModifier, ForceMode.Impulse);

    }

    public override void DisableForm()
    {
        GameManager.Instance.DestroyShape(_shapeGameObject);
    }

    public override void FormUpdate()
    {
        // We don't want anything to happen continuously for this shape
    }
}
