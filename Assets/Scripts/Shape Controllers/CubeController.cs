using UnityEngine;
using System.Collections;

public class CubeController : ShapeController {

    private float _forwardDashForce = 15.0f;
    public float ForwardDashForce { get { return _forwardDashForce; } private set { _forwardDashForce = value; } }

    public GameObject Cube { get { return _shapeGameObject; } }

    public override void InitializeForm(Transform parent)
    {
        _shapeGameObject = GameManager.Instance.InstantiateShape(GameManager.Shapes.Cube);
        _shapeGameObject.transform.position = parent.position;

        //int directionModifier = (Input.GetAxis("Horizontal") >= 0) ? 1 : -1;

        _shapeGameObject.rigidbody.AddForce((Vector3.right) * ForwardDashForce, ForceMode.Impulse); // * directionModifier
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
