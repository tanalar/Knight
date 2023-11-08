using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    [SerializeField] private Button Button;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject icon;

    private void Start()
    {
        Button = GetComponent<Button>();

        if (Button.interactable == true)
        {
            text.SetActive(true);
            icon.SetActive(false);
        }
        else
        {
            text.SetActive(false);
            icon.SetActive(true);
        }
    }
}
