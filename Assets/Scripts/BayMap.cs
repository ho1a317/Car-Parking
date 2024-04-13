using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BayMap : MonoBehaviour
{
    public Text CauntCointsNow;

    public void Bay(int prise)
    {
        if(PlayerPrefs.GetInt("CarCoints") >= prise)
        {
            PlayerPrefs.SetInt("CarCoints", PlayerPrefs.GetInt("CarCoints") - prise);

            PlayerPrefs.SetString("NewMap", "Calidad");

            CauntCointsNow.text = PlayerPrefs.GetInt("CarCoints").ToString();
        }
    }
}
