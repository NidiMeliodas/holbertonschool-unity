using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
	private string previousScene;

	public Toggle invertYToggle;

	private void Start()
	{
		// Get previously saved scene name (default: MainMenu)
		previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");

		// Load the saved Invert Y setting
		invertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;
		Debug.Log("Returning to scene: " + previousScene);

	}

	// Called by BackButton — discards changes
	public void Back()
	{
		SceneManager.LoadScene(previousScene);
	}

	// Called by ApplyButton — saves and returns
	public void Apply()
	{
		// Save invert setting
		PlayerPrefs.SetInt("InvertY", invertYToggle.isOn ? 1 : 0);
		PlayerPrefs.Save();

		// Return to previous scene
		SceneManager.LoadScene(previousScene);
	}
}
