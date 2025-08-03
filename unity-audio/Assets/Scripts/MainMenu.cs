using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Called by Level01, Level02, Level03 buttons
    public void LevelSelect(int level)
    {
        string sceneName = $"Level0{level}";
        SceneManager.LoadScene(sceneName);
    }

    // Called by OptionsButton
    public void Options()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");

    }

    // Called by ExitButton
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
