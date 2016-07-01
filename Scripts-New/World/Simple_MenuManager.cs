using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Simple_MenuManager : MonoBehaviour {


    public void StartGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
