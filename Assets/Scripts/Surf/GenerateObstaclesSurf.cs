using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstaclesSurf : MonoBehaviour
{

    [SerializeField] private GameObject rocher;
    [SerializeField] private GameObject requin;
    private float obstacleDelay = 2f; // tous les x secondes, on génère un obstacle
    private float timerObstacle = 0f;
    private int nbObstacles = 10; //Compteur d'obstacles générés
    private int nbRequins = 5; //S'il y en a tjrs 6, il faudra mettre 4
    private int nbRochers = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerObstacle <= 0 && nbObstacles > 0 && !PlayerManagerSurf.game_over)
        { //Si timerObstacle est inférieur ou égal à 0, on génère un obstacle à une position y aléatoire et on remet timerObstacle = à obstacleDelay
            float departEnY = Random.Range(-4f, 4f);

            int min = 1;
            int max = 3;

            GameObject obstacle = null; 
            if(nbRequins > 0 && nbRochers > 0){ //Si on a pas généré 5 requin ou 5 rochers, c'est aléatoire
                // Effectue le tirage aléatoire
                int tirage = Random.Range(min, max);

                // Instancie soit un rocher soit un requin en fonction du tirage
                
                if (tirage == 1)
                {
                    obstacle = Instantiate(rocher, new Vector2(8, departEnY), Quaternion.identity);
                    nbRochers--;
                }
                else
                {
                    nbRequins--;
                    obstacle = Instantiate(requin, new Vector2(8, departEnY), Quaternion.identity);
                }
            } else if(nbRequins > 0){ //Si on a généré 5 rochers, donc s'il reste des requins, on les génère
                nbRequins--;
                obstacle = Instantiate(requin, new Vector2(8, departEnY), Quaternion.identity);
            } else if(nbRochers > 0){
                obstacle = Instantiate(rocher, new Vector2(8, departEnY), Quaternion.identity);
                nbRochers--;
            }
            nbObstacles--;

            obstacle.transform.parent = this.gameObject.transform; //on met l'objet généré dans l'objet OBsracles qui bouge à droite
            //on remet timerObstacle = à obstacleDelay
            timerObstacle = obstacleDelay;
        } else if (timerObstacle <= 0 && nbObstacles == 0 && !PlayerManagerSurf.game_over)
        { 
            //générer la ligne d'arrivée

            //Si on touche la ligne d'arrivée, il faut regarder la variable qui contient le nombre d'obstacles touchés
            // et afficher la médaille selon les cas
        }
        else
        {
            timerObstacle -= Time.deltaTime; //on enlève le temps qui s'écoule pour faire baisser le chrono
        }
    }
}
