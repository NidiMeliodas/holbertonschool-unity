using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
	private string previousScene;

	private void Start()
	{
		// Save the previous scene's name to return to later
		previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");
	}

	// Called by BackButton
	public void Back()
	{
		SceneManager.LoadScene(previousScene);
	}
}
