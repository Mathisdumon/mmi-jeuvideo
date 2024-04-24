using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerFoot : MonoBehaviour
{
    //Singleton, permet de n'avoir qu'une seule et unique instance de l'objet

    public static PlayerManagerFoot instance;
    public static GameObject player;
    public int touche = 0;
    [SerializeField] UIManager uiManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

    public static GameObject GetPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        return player;
    }

    [SerializeField] private HUD hud; //on joint le hud du canvas
    [SerializeField] private AudioManager audioManager;


    [SerializeField] private float _moveSpeed = 5f; //On définit ici la vitesse du character. Vous pouvez la modifier. 5f = le nombre 5 en float (décimal).
    [SerializeField] private Rigidbody2D _rb; //On place ici le rigidbody du character
    private Vector2 _movement;


    // Fonction qui se lance à chaque frame.
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other) 
    {if (other.tag == "Obstacle")
        {
            Debug.Log("test");
            touche++;
            uiManager.UpdateText();
            Destroy(other.gameObject);
        } 
    }

    void FixedUpdate()
    {
        //On récupère si les touches de directions horizontales et verticales sont pressées, cela donne un nombre entre 0 (pas pressé) et 1 (pressé).
        _movement.y = Input.GetAxisRaw("Vertical");

        //On définit le vecteur de mouvement en fonction des données précédentes.
        _movement = Vector2.up * _movement.normalized.y;

        //Si le chronomètre n'est pas arrêté, on ajoute le laps de temps écoulé au chronomètre et on actualise le HUD
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);

    }
}
