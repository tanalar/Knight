using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private string playerNumber;

    private void OnEnable()
    {
        UI.onSave += Save;
    }
    private void OnDisable()
    {
        UI.onSave -= Save;
    }

    private void Start()
    {
        if(PlayerPrefs.GetFloat(playerNumber+"x") != 0)
        {
            Load();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(playerNumber+"x", transform.position.x);
        PlayerPrefs.SetFloat(playerNumber+"y", -0.017f);
        PlayerPrefs.SetFloat(playerNumber+"z", transform.position.z);
    }

    private void Load()
    {
        transform.position = new Vector3(
                                         PlayerPrefs.GetFloat(playerNumber+"x"),
                                         PlayerPrefs.GetFloat(playerNumber+"y"),
                                         PlayerPrefs.GetFloat(playerNumber+"z")
                                         );
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
