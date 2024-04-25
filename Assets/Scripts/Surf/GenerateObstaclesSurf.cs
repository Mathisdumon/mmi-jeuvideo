using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstaclesSurf : MonoBehaviour
{

    [SerializeField] private GameObject rocher;
    [SerializeField] private GameObject requin;
    private float obstacleDelay = 2f; // tous les x secondes, on génère un obstacle
    private float timerObstacle = 0f;
    private int nbObstacles = 0; //Compteur d'obstacles générés

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerObstacle <= 0 && !PlayerManagerFoot.game_over)
        { //Si timerObstacle est inférieur ou égal à 0, on génère un obstacle à une position y aléatoire et on remet timerObstacle = à obstacleDelay
            float departEnY = Random.Range(-4f, 4f);

            int min = 1;
            int max = 3;

            // Effectue le tirage aléatoire
            int tirage = Random.Range(min, max);

            // Instancie soit un rocher soit un requin en fonction du tirage
            GameObject obstacle; 
            if (tirage == 1)
            {
                obstacle = Instantiate(rocher, new Vector2(8, departEnY), Quaternion.identity);
            }
            else
            {
                obstacle = Instantiate(requin, new Vector2(8, departEnY), Quaternion.identity);
            }

            obstacle.transform.parent = this.gameObject.transform; //on met l'objet généré dans l'objet OBsracles qui bouge à droite
            //on remet timerObstacle = à obstacleDelay
            timerObstacle = obstacleDelay;
        }
        else
        {
            timerObstacle -= Time.deltaTime; //on enlève le temps qui s'écoule pour faire baisser le chrono
        }
    }
}
