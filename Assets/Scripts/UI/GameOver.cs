using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text gameOverText;
    public Button restartButton;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowGameOverScreen()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
