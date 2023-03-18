using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squishyProperty : MonoBehaviour
{
    float mass = 1.0f;
    float angularDamping = 0.5f;
    float drag = 10.0f;
    private Rigidbody _rigidbody;

    [Space]

    //deformation
    float deformationAmount = 0.2f;
    float deformationSpeed = 1.0f;

    private Mesh _mesh;
    private Vector3[] _originalVertices;
    private Vector3[] _deformedVertices;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // Change the rigidbody's properties to simulate a soft body
        _rigidbody.mass = mass;
        _rigidbody.drag = drag;
        _rigidbody.angularDrag = angularDamping;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        //deformation
        _mesh = GetComponent<MeshFilter>().mesh;
        _originalVertices = _mesh.vertices;
        _deformedVertices = new Vector3[_originalVertices.Length];
    }

    private void Update()
    {
        for (int i = 0; i < _originalVertices.Length; i++)
        {
            Vector3 direction = _originalVertices[i] - transform.position;
            float distance = direction.magnitude;
            direction.Normalize();

            _deformedVertices[i] = _originalVertices[i] + direction * deformationAmount * Mathf.Sin(distance * deformationSpeed + Time.time);
        }

        _mesh.vertices = _deformedVertices;
        _mesh.RecalculateNormals();
    }
}

