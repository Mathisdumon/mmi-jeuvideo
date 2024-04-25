using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinishLineSurf : MonoBehaviour
{

	[SerializeField] private GameObject gold;
	[SerializeField] private GameObject silver;
	[SerializeField] private GameObject bronze;


    void OnTriggerEnter2D(Collider2D col)
	{
		//Si l'obstacle entre en collision avec le joueur (objet avec le tag "Player")
		if (col.gameObject.tag == "Player")
		{
			PlayerManagerSurf pms = col.gameObject.GetComponent<PlayerManagerSurf>();
			
			pms.ShowMedaille();
			
			//
			//On immobilise le joueur pendant 0.5 s
			PlayerManager.SetFreeze(0.5f);
		}
	}
}
