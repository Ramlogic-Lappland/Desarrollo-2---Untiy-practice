using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float force = 500f;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Fire()
    {
        _rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
