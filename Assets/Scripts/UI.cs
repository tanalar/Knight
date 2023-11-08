using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject turnCounter;

    [SerializeField] private GameObject helpButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject nextButton;

    [SerializeField] private GameObject music;

    [SerializeField] private GameObject musicOn;
    [SerializeField] private GameObject musicOff;
    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;

    public static Action onSave;
    public static Action onHelp;

    private void OnEnable()
    {
        Goal.onLevelComplete += WinMenu;
        Goal.onPlayerHitGoal += HideHelp;
    }
    private void OnDisable()
    {
        Goal.onLevelComplete -= WinMenu;
        Goal.onPlayerHitGoal -= HideHelp;
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("HelpIsActive") == 1)
        {
            Help();
        }
        music = GameObject.FindWithTag("Music");

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
        else
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }

        PlayerPrefs.SetInt("CurrentLvl", SceneManager.GetActiveScene().buildIndex);
    }

    public void Help()
    {
        if (PlayerPrefs.GetInt("HelpIsActive") == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (helpMenu.activeInHierarchy == false)
        {
            helpMenu.SetActive(true);
            onHelp?.Invoke();
            pauseMenu.SetActive(false);
            PlayerPrefs.SetInt("HelpIsActive", 1);
        }
    }

    public void Pause()
    {
        helpMenu.SetActive(false);

        if (pauseMenu.activeInHierarchy == false)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(31);
        onSave?.Invoke();
    }
    public void Music()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        music.GetComponent<Music>().SetMusic();
    }
    public void Sound()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 1);
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
    }

    public void Restart()
    {
        ResetSave();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        ResetSave();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void WinMenu()
    {
        helpMenu.SetActive(false);
        pauseMenu.SetActive(false);
        turnCounter.SetActive(false);
        helpButton.SetActive(false);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);

        nextButton.SetActive(true);
    }

    private void ResetSave()
    {
        PlayerPrefs.SetFloat("1x", 0);
        PlayerPrefs.SetFloat("1y", 0);
        PlayerPrefs.SetFloat("1z", 0);

        PlayerPrefs.SetFloat("2x", 0);
        PlayerPrefs.SetFloat("2y", 0);
        PlayerPrefs.SetFloat("2z", 0);

        PlayerPrefs.SetFloat("3x", 0);
        PlayerPrefs.SetFloat("3y", 0);
        PlayerPrefs.SetFloat("3z", 0);

        PlayerPrefs.SetFloat("4x", 0);
        PlayerPrefs.SetFloat("4y", 0);
        PlayerPrefs.SetFloat("4z", 0);

        PlayerPrefs.SetFloat("5x", 0);
        PlayerPrefs.SetFloat("5y", 0);
        PlayerPrefs.SetFloat("5z", 0);

        PlayerPrefs.SetFloat("6x", 0);
        PlayerPrefs.SetFloat("6y", 0);
        PlayerPrefs.SetFloat("6z", 0);
    }

    private void HideHelp()
    {
        helpMenu.SetActive(false);
    }
}
