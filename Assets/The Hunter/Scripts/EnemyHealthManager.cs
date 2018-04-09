using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour 
{
	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	private PlayerStats theplayerStats;
	public int expToGive;
	void Start () 
	{
		//Configurando la vida inicial del enemigo
		enemyCurrentHealth = enemyMaxHealth;
		theplayerStats = FindObjectOfType<PlayerStats> ();
	}
	void Update () 
	{
		if(enemyCurrentHealth <= 0) 
		{
			Destroy (gameObject);
			//Al destruir el enemigo añade la experiencia al jugador, así subirá de nivel
			theplayerStats.AddExpirience (expToGive);
		}
	}

	public void HurtEnemy(int damageToGive) 
	{
		//Cuando el jugador toca el enemigo este sufrirá daño
		enemyCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth () 
	{
		enemyCurrentHealth = enemyMaxHealth;
	}
}
