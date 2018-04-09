using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
	private Animator playerAnim;
	private Rigidbody2D playerRigidBody;
	private bool playerMoving;
	public Vector2 lastMovement;
	private static bool playerExists;
	private bool playerAttack;
	public float playerAttackTime;
	private float playerAttackTimeCounter;
	public string startPoint;
	void Start () {

		//Se llama el componente de animator y rigidbody2d
		playerAnim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody2D> ();
		
		if (!playerExists)
		{
			playerExists = true;
			//No destruir el objeto cuando cargue una nueva escena
			DontDestroyOnLoad (transform.gameObject);
		}
		else 
		{
			Destroy (gameObject);
		}	
	}
	void Update () {

		playerMoving = false;

		//Si el jugador no ataca el no accedera a la animacion de ataque
		if (!playerAttack) 
		{		
			//Moviendo de derecha a izquierda
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) 
			{
				//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				playerRigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, playerRigidBody.velocity.y);
				playerMoving = true;
				lastMovement = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			//Moviendo de arriba a abajo
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));

				playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMovement = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			//Si el jugador no se mueve este se detiene
			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f)
				playerRigidBody.velocity = new Vector2 (0f, playerRigidBody.velocity.y);

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f)
				playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, 0f);

			//Si presiono Z el personaje atacará
			if (Input.GetKeyDown (KeyCode.Z)) 
			{
				playerAttackTimeCounter = playerAttackTime;
				playerAttack = true;
				playerRigidBody.velocity = Vector2.zero;
				playerAnim.SetBool ("PlayerAttacking", true);
			}

			//Toma el valor del axis y lo convierte en un valor de 0 o 1, así sabremos cual esta tomando
			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) 
			{
				//Esto hará que el personaje se mueva diagonalmente
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			}
			else 
			{
				currentMoveSpeed = moveSpeed;
			}
		}

		//Cuando el contador incrementa el volvera a 0
		if(playerAttackTimeCounter > 0)
		{
			playerAttackTimeCounter -= Time.deltaTime;
		}
		//Reinicia la animacion de ataque del jugador
		if (playerAttackTimeCounter <= 0){
			playerAttack = false;
			playerAnim.SetBool ("PlayerAttacking", false);
		}

		//atributos para poner en el animator
		playerAnim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		playerAnim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		playerAnim.SetBool ("PlayerMoving", playerMoving);
		playerAnim.SetFloat ("LastMoveX", lastMovement.x);
		playerAnim.SetFloat ("LastMoveY", lastMovement.y);
	}
}
