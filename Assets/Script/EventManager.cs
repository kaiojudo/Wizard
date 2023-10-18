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
    private GameObject jumpBtn;
    private GameObject leftBtn;
    private GameObject rightBtn;
    private GameObject atkJBtn;
    private GameObject atkKBtn;
    private GameObject atkLBtn;

    public static bool checkAudio = true;
    public bool isPause = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;

    public static bool onofSOund = true;
    private void Start()
    {
        jumpBtn = GameObject.Find("JumpBtn");
        leftBtn = GameObject.Find("LeftBtn");
        rightBtn = GameObject.Find("RightBtn");
        atkJBtn = GameObject.Find("ATKJ");
        atkKBtn = GameObject.Find("ATKK");
        atkLBtn = GameObject.Find("ATKL");
        srcBg.clip = bgAudio;

        if(checkAudio)
        {
            srcBg.Play();
        }

    }
    void Update()
    {

        if (onofSOund)
        {
            jumpBtn.SetActive(true);
            leftBtn.SetActive(true);
            rightBtn.SetActive(true);
            atkJBtn.SetActive(true);
            atkKBtn.SetActive(true);
            atkLBtn.SetActive(true);
        }
        else
        {
            jumpBtn.SetActive(false);
            leftBtn.SetActive(false);
            rightBtn.SetActive(false);
            atkJBtn.SetActive(false);
            atkKBtn.SetActive(false);
            atkLBtn.SetActive(false);
        }
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
        onofSOund = true;


    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        onofSOund = false;

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
