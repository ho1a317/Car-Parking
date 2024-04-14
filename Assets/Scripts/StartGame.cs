using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static bool isGameStart = false;
    public GameObject Logo, PlayImage , CauntMooves , LoosText , WinText, ShopImage;

    private bool isLooseGame = false , isWinGame = false ;

    public void PlayGame()
    {
        if (!isLooseGame && !isWinGame)
        {
            isGameStart = true;
            Logo.SetActive(false);
            PlayImage.SetActive(false);
            CauntMooves.SetActive(true);
            ShopImage.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public void WinGame()
    {
        isWinGame = true;
        Logo.SetActive(true);
        PlayImage.SetActive(true);
        WinText.SetActive(true);
        ShopImage.SetActive(true);
        CauntMooves.SetActive(false);

        PlayerPrefs.SetInt("Game Level", PlayerPrefs.GetInt("Game Level") + 1);
    }

    public void LoosGame()
    {
        isLooseGame = true;
        isGameStart = false;
        Logo.SetActive(false);
        PlayImage.SetActive(true);
        CauntMooves.SetActive(false);
        LoosText.SetActive(true);
        ShopImage.SetActive(true);
    }
}
