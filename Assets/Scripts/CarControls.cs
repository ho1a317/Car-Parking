using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Righr, Left, Top, Bottom, None
    }

    private Direktion CarDirektionX = Direktion.None;
    private Direktion CarDirektionY = Direktion.None;

    public enum Axis
    {
        Vertical, Horizontal
    }

    public Axis CarAxis;

    public Text CauntMoove , CauntMoney;
    public GameObject StartGameBan;

    [NonSerialized] public Vector3 FinalPositions;

    private Rigidbody rb;

    private static int CauntCars = 0;

    private new AudioSource audio;
    public AudioClip AudioStart, AudioCrash;

    public ParticleSystem CrashEffect;

    private void Awake()
    {
        CauntCars++;

        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!StartGame.isGameStart) return;

        curPointX = Input.mousePosition.x;
        curPointY = Input.mousePosition.y;
        //Для телефона
        //curPointX = Input.GetTouch(0).position.x;
        //curPointY = Input.GetTouch(0).position.y;
        //переписать OnMouseUp()
    }
    //Для телефона
    private void OnMouseUp()
    {
        if (!StartGame.isGameStart) return;

        if (Input.mousePosition.x - curPointX > 0)
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

        CauntMoove.text = Convert.ToString(Convert.ToInt32(CauntMoove.text) - 1);

        audio.Stop();
        audio.clip = AudioStart;
        audio.Play();

    }

    private void Update()
    {
        if (CauntMoove.text == "0" && CauntCars > 0 && !isClik)
        {
            StartGameBan.GetComponent<StartGame>().LoosGame();
        }

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
            PlayerPrefs.SetInt("CarCoints",PlayerPrefs.GetInt("CarCoints") + 1);
            CauntMoney.text = Convert.ToString(Convert.ToInt32(CauntMoney.text) + 1);
            CauntCars--;

            if(CauntCars == 0)
            {
                StartGameBan.GetComponent <StartGame>().WinGame();
            }

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
        if (col.CompareTag("Car") || col.CompareTag("Borer"))
        {
            Destroy(
                Instantiate(CrashEffect, col.ClosestPoint(transform.position), Quaternion.Euler(new Vector3(270, 0, 0)))
                ,2f);


            if (audio.clip != AudioCrash && !audio.isPlaying)
            {
                audio.Stop();
                audio.clip = AudioCrash;
                audio.Play();
            }

            if (CarAxis == Axis.Horizontal && isClik)
            {
                float adding = CarDirektionX == Direktion.Left ? 0.5f : -0.5f;
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
