using UnityEngine;

public class FirstSetup : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("FirstSetup") != 1)
        {
            PlayerPrefs.SetInt("FirstSetup", 1);
            PlayerPrefs.SetInt("Music", 1);
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("CurrentLvl", 1);
            PlayerPrefs.SetInt("FirstTip", 1);
        }
    }
}
