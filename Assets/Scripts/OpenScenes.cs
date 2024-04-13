using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScenes : MonoBehaviour
{
    public void OpenNewScenes(string name)
    {
        SceneManager.LoadScene(name);
    }
}
