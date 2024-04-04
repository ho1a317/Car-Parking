using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static bool isGameStart = false;
    public GameObject Logo, PlayImage , CauntMooves , LoosText;

    private bool isLooseGame = false;

    public void PlayGame()
    {
        if (!isLooseGame)
        {
            isGameStart = true;
            Logo.SetActive(false);
            PlayImage.SetActive(false);
            CauntMooves.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public void LoosGame()
    {
        isLooseGame = true;
        isGameStart = false;
        Logo.SetActive(false);
        PlayImage.SetActive(true);
        CauntMooves.SetActive(false);
        LoosText.SetActive(true);
    }
}
