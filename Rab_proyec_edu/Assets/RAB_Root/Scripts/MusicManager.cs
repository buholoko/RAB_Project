using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
            ChangeMusic(menuMusic);
        else
            ChangeMusic(gameMusic);
    }

    void ChangeMusic(AudioClip newClip)
    {
        if (audioSource.clip == newClip) return;

        audioSource.clip = newClip;
        audioSource.Play();
    }
}
