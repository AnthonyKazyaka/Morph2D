using UnityEngine;
using System.Collections;

public class StarController : ShapeController
{
    private float _verticalVeloctiyModifier = 0.90f;
    public float VerticalVelocityModifier { get { return _verticalVeloctiyModifier; } }

    public float HorizontalSpeed { get { return _shapeGameObject.rigidbody.velocity.x; } }

    private float _horizontalSpeedModifier = 200.0f;

    public const float MaxHorizontalSpeed = 15.0f;

    public GameObject Star { get { return _shapeGameObject; } }

    protected override void InitializeForm(Transform playerTransform)
    {
        _shapeGameObject = GameManager.Instance.InstantiateShape(GameManager.Shapes.Star);
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
        Vector3 modifiedVelocity = _shapeGameObject.gameObject.rigidbody.velocity;
        modifiedVelocity.y *= _verticalVeloctiyModifier;
        _shapeGameObject.rigidbody.velocity = modifiedVelocity;

 
        Vector3 forceVector = new Vector3(_horizontalSpeedModifier * Input.GetAxis("Horizontal") * Time.deltaTime, 0.0f, 0.0f);
        _shapeGameObject.rigidbody.AddForce(forceVector, ForceMode.Acceleration);
        if (_shapeGameObject.rigidbody.velocity.x > MaxHorizontalSpeed)
            _shapeGameObject.rigidbody.velocity = new Vector3(MaxHorizontalSpeed, _shapeGameObject.rigidbody.velocity.y, _shapeGameObject.rigidbody.velocity.z);
    }
}
