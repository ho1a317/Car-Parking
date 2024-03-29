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

    private float curPointX;
    private float curPointY;

    private enum Direktion
    {
        Righr,Left,Top,Bottom,None
    }

    private Direktion CarDirektionX = Direktion.None;
    private Direktion CarDirektionY = Direktion.None;

    public enum Axis
    {
        Vertical, Horizontal
    }

    public Axis CarAxis;

    [NonSerialized] public Vector3 FinalPositions;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        curPointX = Input.mousePosition.x;
        curPointY = Input.mousePosition.y;
        //Для телефона
        // curPointX = Input.GetTouch(0).position.x;
        // curPointY = Input.GetTouch(0).position.y;
        //переписать OnMouseUp()
    }

    private void OnMouseUp()
    {
        if(Input.mousePosition.x - curPointX > 0)
        {
            CarDirektionX = Direktion.Righr;
        }
        else
        {
            CarDirektionX = Direktion.Left;
        }
        if (Input.mousePosition.y - curPointY > 0)
        {
            CarDirektionY = Direktion.Top;
        }
        else
        {
            CarDirektionY = Direktion.Bottom;
        }
        isClik = true;
    }

    private void Update()
    {
        MovCar();
    }

    private void FixedUpdate()
    {
        AxisControls();
    }

    private void MovCar()
    {
        if (FinalPositions.x != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, FinalPositions, fainalSpeed * Time.deltaTime);

            Vector3 lookAtPos = FinalPositions - transform.position;
            lookAtPos.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookAtPos), Time.deltaTime * rotationSpeed);
        }

        if (transform.position == FinalPositions)
        {
            Destroy(gameObject);
        }
    }

    private void AxisControls()
    {
        if (isClik && FinalPositions.x == 0)
        {
            Vector3 whichWay = CarAxis == Axis.Horizontal ? Vector3.forward : Vector3.left;

            speed = Mathf.Abs(speed);

            if (CarDirektionX == Direktion.Left && CarAxis == Axis.Horizontal)
            {
                speed *= -1;
            }
            else if (CarDirektionY == Direktion.Bottom && CarAxis == Axis.Vertical)
            {
                speed *= -1;
            }

            rb.MovePosition(rb.position + whichWay * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Car") || col.CompareTag("Borer"))
        {
            if(CarAxis == Axis.Horizontal && isClik)
            {
                float adding = CarDirektionX == Direktion.Left ? 0.5f : - 0.5f;
                transform.position = new Vector3(transform.position.x, 0, transform.position.z + adding);
            }

            if (CarAxis == Axis.Vertical && isClik)
            {
                float adding = CarDirektionY == Direktion.Top ? 0.5f : -0.5f;
                transform.position = new Vector3(transform.position.x + adding, 0, transform.position.z);
            }
           
            isClik = false;
        }
    }

}
