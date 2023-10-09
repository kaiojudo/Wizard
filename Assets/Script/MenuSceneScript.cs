using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuSceneScript : MonoBehaviour
{
    public GameObject guildMenu;
    // Start is called before the first frame update
    public void Start()
    {
        guildMenu.SetActive(false);

    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        Player.currentScene = 1;
        Player.currentHealth = 100;
        Time.timeScale = 1f;

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenGuild()
    {
        guildMenu.SetActive(true);
    }
    public void CloseGuild()
    {
        guildMenu.SetActive(false);
    }
}
