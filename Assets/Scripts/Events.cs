using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{

    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
        
    }

    public void StartGame()
    {
        PlayerManager.isGameStarted = true;
    }

    public void ShopMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SettingsMenu()
    {
        //SceneManager.LoadScene("Settings");
    }

    public void stoppingTrue()
    {
        PlayerManager.stopping = true;
    }

    public void stoppingFalse()
    {
        PlayerManager.stopping = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
