using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioSource pick;
    [SerializeField] AudioSource swap;
    [SerializeField] AudioSource stay;

    private void OnEnable()
    {
        Player.onSound += Play;
    }
    private void OnDisable()
    {
        Player.onSound -= Play;
    }

    private void Play(int sound)
    {
        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            if (sound == 1)
            {
                pick.Play();
            }
            if (sound == 2)
            {
                swap.Play();
            }
            if (sound == 3)
            {
                stay.Play();
            }
        }
    }
}
