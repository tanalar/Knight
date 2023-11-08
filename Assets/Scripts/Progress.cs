using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] private Button[] lvlButtons;

    private void Awake()
    {
        int lvlAt = PlayerPrefs.GetInt("lvlAt", 1);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > lvlAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }
}
