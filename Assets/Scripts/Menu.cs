using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject ChooseLevelPanel;
    [SerializeField] GameObject BloomEffect;

    public static Action onStart;

    public void PressStart()
    {
        StartButton.SetActive(false);
        ChooseLevelPanel.SetActive(true);

        onStart?.Invoke();
        BloomEffect.GetComponent<MenuBloom>().enabled = false;
    }
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLvl"));
    }

    public void Blue1()
    {
        resetSave();
        SceneManager.LoadScene(1);
    }
    public void Blue2()
    {
        resetSave();
        SceneManager.LoadScene(2);
    }
    public void Blue3()
    {
        resetSave();
        SceneManager.LoadScene(3);
    }
    public void Blue4()
    {
        resetSave();
        SceneManager.LoadScene(4);
    }
    public void Blue5()
    {
        resetSave();
        SceneManager.LoadScene(5);
    }
    public void Blue6()
    {
        resetSave();
        SceneManager.LoadScene(6);
    }
    public void Blue7()
    {
        resetSave();
        SceneManager.LoadScene(7);
    }
    public void Blue8()
    {
        resetSave();
        SceneManager.LoadScene(8);
    }
    public void Blue9()
    {
        resetSave();
        SceneManager.LoadScene(9);
    }
    public void Blue10()
    {
        resetSave();
        SceneManager.LoadScene(10);
    }
    public void Purple1()
    {
        resetSave();
        SceneManager.LoadScene(11);
    }
    public void Purple2()
    {
        resetSave();
        SceneManager.LoadScene(12);
    }
    public void Purple3()
    {
        resetSave();
        SceneManager.LoadScene(13);
    }
    public void Purple4()
    {
        resetSave();
        SceneManager.LoadScene(14);
    }
    public void Purple5()
    {
        resetSave();
        SceneManager.LoadScene(15);
    }
    public void Purple6()
    {
        resetSave();
        SceneManager.LoadScene(16);
    }
    public void Purple7()
    {
        resetSave();
        SceneManager.LoadScene(17);
    }
    public void Purple8()
    {
        resetSave();
        SceneManager.LoadScene(18);
    }
    public void Purple9()
    {
        resetSave();
        SceneManager.LoadScene(19);
    }
    public void Purple10()
    {
        resetSave();
        SceneManager.LoadScene(20);
    }
    public void Red1()
    {
        resetSave();
        SceneManager.LoadScene(21);
    }
    public void Red2()
    {
        resetSave();
        SceneManager.LoadScene(22);
    }
    public void Red3()
    {
        resetSave();
        SceneManager.LoadScene(23);
    }
    public void Red4()
    {
        resetSave();
        SceneManager.LoadScene(24);
    }
    public void Red5()
    {
        resetSave();
        SceneManager.LoadScene(25);
    }
    public void Red6()
    {
        resetSave();
        SceneManager.LoadScene(26);
    }
    public void Red7()
    {
        resetSave();
        SceneManager.LoadScene(27);
    }
    public void Red8()
    {
        resetSave();
        SceneManager.LoadScene(28);
    }
    public void Red9()
    {
        resetSave();
        SceneManager.LoadScene(29);
    }
    public void Red10()
    {
        resetSave();
        SceneManager.LoadScene(30);
    }

    private void resetSave()
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

        PlayerPrefs.SetInt("HelpIsActive", 0);
    }
}
