using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoatTriger : MonoBehaviour
{
    public Vector3 FinalPositions;

    private void OnTriggerEnter(Collider car)
    {
        if (car.CompareTag("Car"))
        {
            car.GetComponent<CarControls>().FinalPositions = FinalPositions;
        }
    }

}
