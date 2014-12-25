using UnityEngine;
using System.Collections;

public class TriangleController : ShapeController
{
    private float _upwardDashForce = 7.50f;
    public float UpwardDashForce { get { return _upwardDashForce; } private set { _upwardDashForce = value; } }

    public GameObject Triangle { get { return _shapeGameObject; } }

    protected override void InitializeForm(Transform playerTransform)
    {
        _shapeGameObject = GameManager.Instance.InstantiateShape(GameManager.Shapes.Triangle);
        _shapeGameObject.transform.position = playerTransform.position;
    }

    public override void InitializeFormWithVelocity(Transform playerTransform, Vector3 velocity)
    {
        InitializeForm(playerTransform);

        SetShapeVelocity(velocity);

        _shapeGameObject.rigidbody.AddForce((Vector3.up) * UpwardDashForce, ForceMode.Impulse);
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
