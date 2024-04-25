using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerFoot : MonoBehaviour
{
    [SerializeField] TMP_Text compteurTexte;
    [SerializeField] GameObject popUpEnding;
    [SerializeField] TMP_Text scoreText;
    PlayerManagerFoot playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("Character").GetComponent<PlayerManagerFoot>();
        compteurTexte.text = playerManager.nbPoint.ToString();
        scoreText = popUpEnding.GetComponentInChildren<TMP_Text>();
        popUpEnding.SetActive(false);
    }

    public void EndingGame()
    {
        popUpEnding.SetActive(true);
        scoreText.text = playerManager.nbPoint.ToString();
    }
    public void UpdateText()
    {
        compteurTexte.text = playerManager.nbPoint.ToString();
    }
}
