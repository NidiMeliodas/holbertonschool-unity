using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Timer timer;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        if (timer != null)
            timer.isRunning = false;
        isPaused = true;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        if (timer != null)
            timer.isRunning = true;
        isPaused = false;
    }

    // 🔁 Restart current scene
    public void Restart()
    {
        Time.timeScale = 1f; // Ensure time is resumed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 🏠 Go to Main Menu
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // ⚙️ Load Options Scene
    public void Options()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");

    }
}
