using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompteurCollision : MonoBehaviour
{
    // Référence au compteur
    public Text compteurText;

    // Compteur de collisions
    public int compteur = 0;

    // Méthode appelée lorsqu'un objet entre en collision avec le trigger
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet en collision est un ballon

        // Incrémenter le compteur
        compteur++;
        // Mettre à jour le texte du compteur
        compteurText.text = "Nombre de ballons touchés : " + compteur;
        Debug.Log(compteur);

    }
}
