using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenupanel;
    public static MainMenu Instance { get; private set; }
    public GameObject introCanvas, intro, tryAgainPanel, player, audioManager;
    public VideoPlayer introPlayer;
    public TextMeshProUGUI messageText;
    public static bool isRestart = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        introPlayer.loopPointReached += IntroPlayer_LoopPointReached;
    }

    private void IntroPlayer_LoopPointReached(VideoPlayer source)
    {
        OnVideoEnd();
    }

    public void PlayGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (isRestart != true)
        {
            introCanvas.SetActive(true);
            intro.SetActive(true);
        }
        else
        {
            OnVideoEnd();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        mainMenupanel.SetActive(false);

    }
    public void OnVideoEnd()
    {
        intro.SetActive(false);
        introCanvas.SetActive(false);
        audioManager.SetActive(true);
        player.SetActive(true);
    }
    public void TryAgain()
    {
        isRestart = true;
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GameOver(string message)
    {
        tryAgainPanel.SetActive(true);
        if (message != "")
        {
            messageText.text = message;
        }
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }



}//class
