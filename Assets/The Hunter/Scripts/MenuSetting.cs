using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSetting : MonoBehaviour 
{
	public bool settings;
	public GameObject settingsCanvas;
	public GameObject howToPlayCanvas;
	public bool plays;
	public string mainMenu;
	public bool controls;
	public GameObject controlsCanvas;
	// Use this for initialization
	public void SettingGame()
	{
		
		if(this.settings)
		{
			settingsCanvas.SetActive(true);
		}

		else
		{
			settingsCanvas.SetActive(false);
		}

		if(Input.GetKeyDown (KeyCode.Mouse0))
		{
			this.settings = !this.settings;
		}	
	}

	public void AboutTheGame()
	{
		
		if(this.plays)
		{
			howToPlayCanvas.SetActive(true);
		}

		else
		{
			howToPlayCanvas.SetActive(false);
		}

		if(Input.GetKeyDown (KeyCode.Mouse0))
		{
			this.plays = !this.plays;
		}	
	}

	public void ControlScheme()
	{
		if(this.controls)
		{
			controlsCanvas.SetActive(true);
		}

		else
		{
			controlsCanvas.SetActive(false);
		}

		if(Input.GetKeyDown (KeyCode.Mouse0))
		{
			this.controls = !this.controls;
		}
	}
	
	public void QuitToMainMenu ()
	{
		SceneManager.LoadScene (this.mainMenu);
	}
}
