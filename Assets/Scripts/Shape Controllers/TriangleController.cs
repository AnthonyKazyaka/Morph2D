using UnityEngine;
using System.Collections;

public class TriangleController : ShapeController
{
    private float _upwardDashForce = 7.50f;
    public float UpwardDashForce { get { return _upwardDashForce; } private set { _upwardDashForce = value; } }

    public GameObject Triangle { get { return _shapeGameObject; } }

    public override void InitializeForm(Transform parent)
    {
        _shapeGameObject = GameManager.Instance.InstantiateShape(GameManager.Shapes.Triangle);
        _shapeGameObject.transform.position = parent.position;
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
