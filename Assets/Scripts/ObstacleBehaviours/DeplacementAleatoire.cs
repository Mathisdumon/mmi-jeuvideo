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
    private float vitesse;
    public float vitesseAleatoire;

    // Booléen pour indiquer si le ballon est en mouvement
    private bool enMouvement = false;

    void Start()
    {
        vitesse = Random.Range(8f, 15f);
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
        // faire en sorte que le ballon aie des coordonnées aléatoire pour qu'il aille dans vers ces coordonnées
        nbAleatoireEnYFin = Random.Range(-4.3f, 4.3f);
        finEnY = nbAleatoireEnYFin;
        finEnX = -8.5f;

        // // Définir une vitesse aléatoire entre vitesseMin et vitesseMax
        // float vitesseAleatoire = Random.Range(vitesseMin, vitesseMax);

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

                // revoir la partie qui suit
                ballSpawner.CreateNewBallon();
                Destroy(gameObject);

            }
        }
    }

    // Méthode pour faire apparaître un nouveau ballon
}
