using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text toucheTexte;
    [SerializeField] GameObject gameOverPanel;
    
    PlayerManagerFoot playerManagerFoot;

    // Start is called before the first frame update
    void Start()
    {
        playerManagerFoot = GameObject.Find("Surfer").GetComponent<PlayerManagerFoot>();
        toucheTexte.text = playerManagerFoot.touche.ToString();
        gameOverPanel.SetActive(false); //on le cache au début
    }


    public void UpdateText()
    {
        toucheTexte.text = playerManagerFoot.touche.ToString();
    }

    public void ShowGameOverScreen(){
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
