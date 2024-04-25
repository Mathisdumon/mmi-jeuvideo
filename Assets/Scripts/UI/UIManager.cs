using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text toucheTexte;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject endPanel;
    
    PlayerManagerSurf playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("Surfer").GetComponent<PlayerManagerSurf>();
        toucheTexte.text = playerManager.touche.ToString();
        gameOverPanel.SetActive(false); //on le cache au début
    }


    public void UpdateText()
    {
        toucheTexte.text = playerManager.touche.ToString();
    }

    public void ShowGameOverScreen(){
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        PlayerManagerSurf.game_over = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void showMedailleScreen(int medaille){
        endPanel.SetActive(true);
        endPanel.GetComponent<Medailles>().showMedaille(medaille);
    }
}
