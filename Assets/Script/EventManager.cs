using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] AudioSource srcBg;
    [SerializeField] AudioClip bgAudio;
    [SerializeField] AudioSource srcMove;
    [SerializeField] AudioSource srcCombat;
    [SerializeField] Image mute;
    [SerializeField] Sprite newImg;
    private Sprite f_newImg;

    public static bool checkAudio = true;
    public bool isPause = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    private void Start()
    {
        srcBg.clip = bgAudio;

        if(checkAudio)
        {
            srcBg.Play();
        }
    }
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void ReStart()
    {
        SceneManager.LoadScene(1);
        Player.currentScene = 1;
        Player.life = 2;
        Player.point = 0;
        Player.currentHealth = 100;
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Player.currentScene = 1;
        Player.currentHealth = 100;
        Player.life = 2;
        Player.point = 0;
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void SoundOnOff()
    {
        if (checkAudio)
        {
            srcBg.Pause();
            srcCombat.Pause();
            srcMove.Pause();
            checkAudio = false;
        }
        else
        {
            srcBg.UnPause();
            srcCombat.UnPause();
            srcMove.UnPause();
            checkAudio = true;
        }
        f_newImg = mute.sprite;
        mute.sprite = newImg;
        newImg = f_newImg;
    }
}
