using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string startLevel;
	public int playerHealth;

	public void NewGame ()
	{
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", this.playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", this.playerHealth);
		SceneManager.LoadScene (this.startLevel);
	}
	public void QuitGame ()
	{
		Application.Quit ();
	}
}
