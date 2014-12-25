using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System.Collections;

public class ShapeController
{

    protected GameObject _shapeGameObject;

    public virtual void InitializeForm(Transform parent) { }

    public virtual void DisableForm() { }

    public virtual void FormUpdate() { }

    public Vector3 GetShapePosition()
    {
        return _shapeGameObject.transform.position;
    }

    public Vector3 GetShapeVelocity()
    {
        return _shapeGameObject.rigidbody.velocity;
    }

    public void SetShapeVelocity(Vector3 velocity)
    {
        _shapeGameObject.rigidbody.velocity = velocity;
    }

}
