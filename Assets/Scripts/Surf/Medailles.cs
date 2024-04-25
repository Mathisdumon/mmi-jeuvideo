using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medailles : MonoBehaviour
{

    [SerializeField] private GameObject medaille_or;
    [SerializeField] private GameObject medaille_argent;
    [SerializeField] private GameObject medaille_bronze;

    public void showMedaille(int medaille){
        if(medaille == 1){
            medaille_or.SetActive(true);
        } else if(medaille == 2){
            medaille_argent.SetActive(true);
        } else if(medaille == 3){
            medaille_bronze.SetActive(true);
        }
    }
}
