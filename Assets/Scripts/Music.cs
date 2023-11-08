using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private new string tag;
    [SerializeField] AudioSource music;

    private void Start()
    {
        GameObject obj = GameObject.FindWithTag(this.tag);
        if (obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this.tag;
            DontDestroyOnLoad(this.gameObject);
        }
        SetMusic();
    }

    public void SetMusic()
    {
        if(PlayerPrefs.GetInt("Music") == 1)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
    }
}
