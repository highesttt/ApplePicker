using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
