using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    public GameObject city, calidad;
    private void Start()
    {
        if (PlayerPrefs.GetString("NewMap") == "Calidad")
        {
            calidad.SetActive(true);
        }
        else
        {
            city.SetActive(true);
        }
    }
}
