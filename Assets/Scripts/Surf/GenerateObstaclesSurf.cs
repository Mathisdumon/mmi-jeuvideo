using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenerateObstaclesSurf : MonoBehaviour
{

    [SerializeField] private GameObject rocher;
    [SerializeField] private GameObject requin;
    [SerializeField] private GameObject arrived;
    private float obstacleDelay = 2f; // tous les x secondes, on génère un obstacle
    private float timerObstacle = 0f;
    [SerializeField] private int nbObstacles = 10; //Compteur d'obstacles générés
    private int nbRequins = 5; //Il y en a 2 créés au tout début
    private int nbRochers = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //comment
        if (timerObstacle <= 0 && nbObstacles > 0 && !PlayerManagerSurf.game_over)
        { //Si timerObstacle est inférieur ou égal à 0, on génère un obstacle à une position y aléatoire et on remet timerObstacle = à obstacleDelay
            float departEnY = Random.Range(-4f, 4f);

            int min = 1;
            int max = 3;

            GameObject obstacle = null;
            if (nbRequins > 0 && nbRochers > 0)
            { //Si on a pas généré 5 requin ou 5 rochers, c'est aléatoire
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
            }
            else if (nbRequins > 0)
            { //Si on a généré 5 rochers, donc s'il reste des requins, on les génère
                nbRequins--;
                obstacle = Instantiate(requin, new Vector2(8, departEnY), Quaternion.identity);
            }
            else if (nbRochers > 0)
            {
                obstacle = Instantiate(rocher, new Vector2(8, departEnY), Quaternion.identity);
                nbRochers--;
            }
            nbObstacles--;

            obstacle.transform.parent = this.gameObject.transform; //on met l'objet généré dans l'objet Obsracles qui bouge à droite
            //on remet timerObstacle = à obstacleDelay
            timerObstacle = obstacleDelay;
        }
        else if (timerObstacle <= 0 && nbObstacles == 0 && !PlayerManagerSurf.game_over)
        {
            Debug.Log("ici");
            GameObject ligneArrivee = Instantiate(arrived, new Vector3(8, 0, -1), Quaternion.identity);
            ligneArrivee.SetActive(true);
            ligneArrivee.transform.parent = this.gameObject.transform; 
            timerObstacle = 100f;
            //La ligne d'arrivée est générée ?

            /*
            int Touché = PlayerManagerSurf.touche;

            if (Touché == 0)
            {
                Debug.Log("Aucun obstacle touché. Médaille d'or!");
            }
            else if (Touché == 1)
            {
                Debug.Log("Médaille d'argent!");
            }
            else if (Touché == 2)
            {
                Debug.Log("Médaille de bronze!");
            }
            else
            {
                Debug.Log("Beaucoup obstacle touché. Pas de médaille.");
            }
            */
        }
        else
        {
            timerObstacle -= Time.deltaTime; //on enlève le temps qui s'écoule pour faire baisser le chrono
        }
    }
}
