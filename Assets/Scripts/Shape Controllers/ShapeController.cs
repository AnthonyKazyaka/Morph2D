using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System.Collections;

public class ShapeController
{

    protected GameObject _shapeGameObject;

    private Vector3 _lastVelocity;
    private Vector3 _lastAngularVelocity;

    protected virtual void InitializeForm(Transform playerTransform) { }

    public virtual void InitializeFormWithVelocity(Transform playerTransform, Vector3 velocity) { }

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

    public virtual void SetShapeVelocity(Vector3 velocity)
    {
        _shapeGameObject.rigidbody.velocity = velocity;
    }

    public virtual void SetShapeAngularVelocity(Vector3 angularVelocity)
    {
        _shapeGameObject.rigidbody.angularVelocity = angularVelocity;
    }

    public void PauseShape()
    {
        _lastVelocity = _shapeGameObject.rigidbody.velocity;
        _lastAngularVelocity = _shapeGameObject.rigidbody.angularVelocity;
        _shapeGameObject.rigidbody.velocity = Vector3.zero;
        _shapeGameObject.rigidbody.angularVelocity = Vector3.zero;

        _shapeGameObject.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void UnpauseShape()
    {
        _shapeGameObject.rigidbody.velocity = _lastVelocity;
        _shapeGameObject.rigidbody.angularVelocity = _lastAngularVelocity;

        _shapeGameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

}
