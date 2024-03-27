using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour
{
    public float speed = 5f;
    public float fainalSpeed = 15f;
    public float rotationSpeed = 350f;
    private bool isClik;

    [NonSerialized] public Vector3 FinalPositions;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        isClik = true;
    }

    private void Update()
    {
        if (FinalPositions.x != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, FinalPositions, fainalSpeed * Time.deltaTime);
            //transform.LookAt(FinalPositions);
            Vector3 lookAtPos = FinalPositions - transform.position;
            lookAtPos.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookAtPos), Time.deltaTime * rotationSpeed);
        }

        if(transform.position == FinalPositions)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isClik && FinalPositions.x == 0)
        {
            rb.MovePosition(transform.position + Vector3.forward * speed * Time.fixedDeltaTime);
        }
    }
}
