using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalAutomaticMove : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 20f; //Vitesse de l'objet, modifiable
	[SerializeField] private int xSens = 1; //Le sens de l'objet (1 si en bas, -1 si en haut)
	private Vector2 movement;

	//Au démarrage, défini la variable de mouvement
	void Start()
	{
		movement = new Vector2(xSens, 0);
	}

	//A chaque frame, on bouge l'objet via son rigidbody dans le mouvement défini * la vitesse de l'objet moveSpeed * Time.fixedDeltaTime le laps de temps écoulé en 1 frame
	void FixedUpdate()
	{
		if(!PlayerManagerFoot.game_over){
			transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
		}
	}
}
