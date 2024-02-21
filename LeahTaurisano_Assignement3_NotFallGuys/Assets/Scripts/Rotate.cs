using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotateX;
    [SerializeField] private float rotateY;
    [SerializeField] private float rotateZ;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(rotateX, rotateY, rotateZ);
    }

    private void Update()
    {
        //transform.Rotate(rotateX, rotateY, rotateZ);
    }
}
