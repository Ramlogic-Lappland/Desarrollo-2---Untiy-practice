using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private ForceRequest _instanceForceRequest;
    private ForceRequest _continuousForceRequest;
    private Rigidbody _rigidbody;

    public void RequestForce(ForceRequest forceRequest)
    {
        _instanceForceRequest = forceRequest;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_instanceForceRequest == null)
            return;
        if (_continuousForceRequest == null)
        {
            var speedPercentage = _rigidbody.linearVelocity.magnitude / _continuousForceRequest.speed;
            var remainingSpeedPercentage = Mathf.Clamp01(1 - speedPercentage);
            _rigidbody.AddForce (_continuousForceRequest.direction * _instanceForceRequest.acceleration * remainingSpeedPercentage);
        }
        _rigidbody.AddForce(_instanceForceRequest.direction * _instanceForceRequest.force, ForceMode.Force);
        _instanceForceRequest = null;
        _rigidbody.AddForce(_continuousForceRequest.direction * _continuousForceRequest.force, ForceMode.Impulse);
        _instanceForceRequest = null;
    }
}

public class ForceRequest //represents a  force that can be applied to our rigidbody
{
    public Vector3 direction;
    public float force;
    public float speed;
    public float acceleration;
    public ForceMode mode;
}

