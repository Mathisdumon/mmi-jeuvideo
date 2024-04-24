using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAleatoire : MonoBehaviour
{

    private float nbAleatoireEnYFin;
    private float finEnY;
    private float finEnX;

    BallSpawner ballSpawner;



    // Vitesse de déplacement du ballon
    public float vitesse = 5.0f;

    // Booléen pour indiquer si le ballon est en mouvement
    private bool enMouvement = false;

    void Start()
    {
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
        // faire en sorte que le ballon aie des coordonnées aléatoire pour qu'il aille dans vers ces coordonnées
        nbAleatoireEnYFin = Random.Range(-4.3f, 4.3f);
        finEnY = nbAleatoireEnYFin;
        finEnX = -8.5f;

        // Démarrer le déplacement du ballon
        enMouvement = true;

    }

    void Update()
    {
        // Vérifier si le ballon est en mouvement
        if (enMouvement)
        {
            // Déplacer le ballon de la position de départ à la position de fin
            Vector3 newPosition = Vector3.MoveTowards(transform.position, new Vector2(finEnX, finEnY), vitesse * Time.deltaTime);
            transform.position = newPosition;

            // Vérifier si le ballon est arrivé à sa destination
            if (transform.position == new Vector3(finEnX, finEnY, transform.position.z))
            {
                // Arrêter le mouvement du ballon
                enMouvement = false;
                ballSpawner.nbBallonRestant = ballSpawner.nbBallonRestant--;

                // revoir la partie qui suit
                ballSpawner.ApparaitreBallon();
                Destroy(gameObject);

            }
        }
    }

    // Méthode pour faire apparaître un nouveau ballon
}
