using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour 
{
	public string levelToLoad;

	public string exitPoint;
	private PlayerController thePlayerExit;

	// Use this for initialization
	void Start () 
	{
		thePlayerExit = FindObjectOfType<PlayerController> ();
	}

	//I get here the name of the level
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			SceneManager.LoadScene (levelToLoad);
			thePlayerExit.startPoint = exitPoint;
		}
	}
}
