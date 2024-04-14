using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevel : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "#" + PlayerPrefs.GetInt("Game Level");
    }

    
}
