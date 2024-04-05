using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaundObj : MonoBehaviour
{
    public GameObject SaundControls;

    private static bool isCriated = false;

    void Start()
    {
        if (isCriated) return;

        isCriated = true;

       DontDestroyOnLoad(Instantiate(SaundControls));
    }
}
