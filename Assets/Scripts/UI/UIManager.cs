using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text toucheTexte;
    PlayerManagerFoot playerManagerFoot;

    // Start is called before the first frame update
    void Start()
    {
        playerManagerFoot = GameObject.Find("Surfer").GetComponent<PlayerManagerFoot>();
        toucheTexte.text = playerManagerFoot.touche.ToString();
    }


    public void UpdateText()
    {
        toucheTexte.text = playerManagerFoot.touche.ToString();
    }
}
