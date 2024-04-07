using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMonay : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text =  PlayerPrefs.GetInt("CarCoints").ToString();
    }
}
