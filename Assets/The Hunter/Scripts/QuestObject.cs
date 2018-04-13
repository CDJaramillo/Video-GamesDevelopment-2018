using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour 
{
	public int questNumber;
	public QuestManager theQM;
	public string startText;
	public string endText;
	public bool isEnemyQuest;
	public string targetEnemy;
	public int enemiesToKill;
	private int enemyCount;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isEnemyQuest) 
		{
			if (theQM.enemyQuest == targetEnemy) 
			{
				theQM.enemyQuest = null;
				enemyCount++;
			}

			if (enemyCount >= enemiesToKill) 
			{
				EndQuest ();
			}
		}
	}

	public void StartQuest()
	{
		theQM.ShowQuestText(startText);
	}

	public void EndQuest()
	{
		theQM.ShowQuestText(endText);
		theQM.questCompleted[questNumber] = true;
		gameObject.SetActive(false);
	}
}
