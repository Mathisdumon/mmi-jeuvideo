using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_vers_regle_foot : MonoBehaviour
{
    public void RegleFoot()
    {
        //Mettre entre guillemets le nom de la scène vers laquelle charger
        //Pour utiliser SceneManager, il faut impérativement rajouter "using UnityEngine.SceneManagement;" en haut du script.
        SceneManager.LoadScene("scene_regle_foot");
    }
}
