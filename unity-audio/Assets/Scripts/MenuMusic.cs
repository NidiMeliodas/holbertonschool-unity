using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Plays background music in the MainMenu scene and stops when loading a new scene.
/// </summary>
public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;
    private AudioSource wallpaperMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            wallpaperMusic = GetComponentInChildren<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainMenu")
        {
            wallpaperMusic.Stop();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
