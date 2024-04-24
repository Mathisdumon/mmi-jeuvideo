using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAleatoire : MonoBehaviour
{

    private float nbAleatoireEnYDebut;
    private float departEnX;
    private float departEnY;
    private float nbAleatoireEnYFin;
    private float finEnY;
    private float finEnX;
    private float nbBallonRestant = 10;

    // Vitesse de déplacement du ballon
    public float vitesse = 5.0f;

    // Booléen pour indiquer si le ballon est en mouvement
    private bool enMouvement = false;

    void Start()
    {
        // faire en sorte que le ballon apparaîsse aléatoirement en Y au début 
        nbAleatoireEnYDebut = Random.Range(-8.2f, 4.2f);
        departEnY = nbAleatoireEnYDebut;
        departEnX = 8;
        gameObject.transform.position = new Vector2(departEnX, departEnY);

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
                nbBallonRestant = nbBallonRestant - 1;

                // revoir la partie qui suit
                Destroy(gameObject);

                // GameObject nouveauBallon = Instantiate(prefab, position, rotation);
            }
        }
    }
}
