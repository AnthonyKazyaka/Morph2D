using UnityEngine;
using System.Collections;

public class StarController : ShapeController
{
    private float _verticalVeloctiyModifier = 0.90f;
    public float VerticalVelocityModifier { get { return _verticalVeloctiyModifier; } }

    private float _horizontalSpeed = 0.0f;
    public float HorizontalSpeed { get { return _horizontalSpeed; } private set { _horizontalSpeed = value; } }

    private float _horizontalSpeedModifier = 10.0f;

    public const float MaxHorizontalSpeed = 10.0f;

    public GameObject Star { get { return _shapeGameObject; } }

    public override void InitializeForm(Transform parent)
    {
        _shapeGameObject = GameManager.Instance.InstantiateShape(GameManager.Shapes.Star);
        _shapeGameObject.transform.position = parent.position;
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

        HorizontalSpeed += _horizontalSpeedModifier * Input.GetAxis("Horizontal") * Time.deltaTime;
        if (HorizontalSpeed > MaxHorizontalSpeed)
            HorizontalSpeed = MaxHorizontalSpeed;

        Vector3 movePosition = _shapeGameObject.rigidbody.transform.position + Vector3.right * HorizontalSpeed * Time.deltaTime;
        _shapeGameObject.rigidbody.MovePosition(movePosition);
    }
}
