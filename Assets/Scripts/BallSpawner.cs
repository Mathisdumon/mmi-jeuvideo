using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballonPrefab;
    private float nbAleatoireEnYDebut;
    private float departEnX;
    private float departEnY;
    public int nbBallonRestant;
    private bool partieTermineeAffichee = false;
    private string terminer;
    [SerializeField] UIManagerFoot uiManagerFoot;

    private bool ballonCreated = false;
    // [SerializeField] private HUD hud;

    // Référence au texte de "Partie Terminée"
    // public Text textePartieTerminee;

    void Update()
    {
        if (!ballonCreated && nbBallonRestant < 10)
        {
            ApparaitreBallon();
            ballonCreated = true;
        }
        // if (nbBallonRestant == 10)
        // {
        //     terminer = "Partie terminer !";
        //     Debug.Log(terminer);
        //     return;
        // }
        else if (nbBallonRestant == 10 && !partieTermineeAffichee) // Vérifier si le message n'a pas encore été affiché
        {
            terminer = "Partie terminée !";
            Debug.Log(terminer);
            uiManagerFoot.EndingGame();
            partieTermineeAffichee = true; // Mettre à jour la variable pour indiquer que le message a été affiché
            return;
        }
    }

    public void ApparaitreBallon()
    {
        // faire en sorte que le ballon apparaîsse aléatoirement en Y au début 
        nbAleatoireEnYDebut = Random.Range(-8.2f, 4.2f);
        departEnY = nbAleatoireEnYDebut;
        departEnX = 8;
        gameObject.transform.position = new Vector2(departEnX, departEnY);

        // Instancier un nouveau ballon à la position de départ
        GameObject nouveauBallon = Instantiate(ballonPrefab, new Vector2(8, departEnY), Quaternion.identity);
    }

    public void CreateNewBallon()
    {
        ballonCreated = false;
    }

    // Méthode pour afficher "Partie Terminée"
    // void AfficherPartieTerminee()
    // {
    //     textePartieTerminee.gameObject.SetActive(true);
    // }
}
