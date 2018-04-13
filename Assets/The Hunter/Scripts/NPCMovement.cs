using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour 
{
	public float moveSpeed;
	private Rigidbody2D myRigid;
	public bool walk;
	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;
	private int walkDir;
	public bool canMove;
	private DialogueManager theDM;
	//Aqui declaramos para que el NPC camine a x cantidad de segundos y se pueda desplazar
	//Llamamos el metodo de elegir direcion, asi podrá moverse a cualquier dirección
	void Start () 
	{
		myRigid = GetComponent<Rigidbody2D>();
		theDM = FindObjectOfType<DialogueManager>();
		waitCounter = waitTime;
		waitCounter = walkTime;
		ChooseDir();
		canMove = true;
	}
	void Update () 
	{
		if (!theDM.dActive)
		{
			canMove = true;
		}
		if (!canMove)
		{
			myRigid.velocity = Vector2.zero;
			return;
		}
		if(walk)
		{
			walkCounter -= Time.deltaTime;

			switch(walkDir)
			{
				case 0:
					myRigid.velocity = new Vector2(0, moveSpeed);
					break;
				case 1:
					myRigid.velocity = new Vector2(moveSpeed, 0);
					break;
				case 2:
					myRigid.velocity = new Vector2(0, -moveSpeed);
					break;
				case 3:
					myRigid.velocity = new Vector2(-moveSpeed, 0);
					break;			
			}
			
			if(walkCounter < 0)
			{
				walk = false;
				waitCounter = waitTime;
			}
		}
		else
		{
			waitCounter -=Time.deltaTime;
			myRigid.velocity = Vector2.zero;

			if(waitCounter < 0)
			{
				ChooseDir();
			}
		}
	}
	//Aqui le decimos que elija la dirección que guste
	public void ChooseDir()
	{
		walkDir = Random.Range (0, 4);
		walk = true;
		walkCounter = walkTime;
	}
}
