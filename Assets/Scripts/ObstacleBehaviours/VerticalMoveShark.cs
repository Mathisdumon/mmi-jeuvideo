using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMoveShark : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; //Vitesse de l'objet, modifiable
	[SerializeField] private int ySens = 1; //Le sens de l'objet (-1 si en bas, 1 si en haut)
	[SerializeField] UIManager uiManager;
	private Vector2 movement;
    private float limit = 5f;

	//Au démarrage, défini la variable de mouvement
	void Start(){
		movement = new Vector2(0, ySens);
	}

	//A chaque frame, on bouge l'objet via son rigidbody dans le mouvement défini * la vitesse de l'objet moveSpeed * Time.fixedDeltaTime le laps de temps écoulé en 1 frame
	void FixedUpdate() {
		transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
		//Debug.Log(transform.position.y + " " + limit);
        if(transform.position.y > limit){
            movement = new Vector2(0, -1);
        } else if (transform.position.y < -limit){
           movement = new Vector2(0, 1);
        }

	}
}
