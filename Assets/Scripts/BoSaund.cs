using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoSaund : MonoBehaviour
{
    private AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        StartCoroutine(SaundBacgaund());
    }

    IEnumerator SaundBacgaund()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f,10f));
            Audio.Play();
        }
    }

}
