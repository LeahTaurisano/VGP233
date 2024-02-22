using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotateX;
    [SerializeField] private float rotateY;
    [SerializeField] private float rotateZ;
    [SerializeField] private float badNumber;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(rotateX, rotateY, rotateZ);
        rb.centerOfMass = Vector3.zero;

    }

    private void Update()
    {
        rb.AddTorque(0, 0, badNumber);
        rb.inertiaTensor = new Vector3(1, 1, 1);
    }
}
