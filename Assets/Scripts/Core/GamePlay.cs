using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Touché = 4; // Nombre maximum de fois que le joueur peut être touché
    private int Touche = 0; // Nombre actuel de fois que le joueur a été touché
    public Text gameOverText; // Texte pour afficher le message de fin de jeu
    public Button restartButton; // Bouton pour recommencer le jeu

    void Start()
    {
        gameOverText.gameObject.SetActive(false); // Désactiver le texte de fin de jeu au début
        restartButton.gameObject.SetActive(false); // Désactiver le bouton de recommencement au début
    }

    // Fonction appelée depuis un autre script pour signaler que le joueur a été touché
    public void PlayerHit()
    {
        Touche++; // Incrémenter le nombre de fois que le joueur est touché

        // Vérifier si le joueur a été touché le nombre maximum de fois
        if (Touche >= Touché)
        {
            EndGame(); // Appeler la fonction de fin de jeu
        }
    }

    void EndGame()
    {
        // Afficher le message de fin de jeu
        gameOverText.text = "Game Over!";
        gameOverText.gameObject.SetActive(true);

        // Afficher le bouton de recommencement
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        // Recharger la scène actuelle pour recommencer le jeu
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
