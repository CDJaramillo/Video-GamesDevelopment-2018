using UnityEngine;
using System.Collections;

public class ScorePoints : MonoBehaviour
{
	public int pointsToAdd;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Slime") 
		{
			ScoreManager.score ++;
			Destroy(gameObject);
		}

		if (other.gameObject.tag == "Ghost")
		{
			ScoreManager.score ++;
			Destroy(gameObject);
		}

		ScoreManager.AddPoints (this.pointsToAdd);
	}
}
