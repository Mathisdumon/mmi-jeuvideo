using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballonPrefab;
    private float nbAleatoireEnYDebut;
    private float departEnX;
    private float departEnY;
    public int nbBallonRestant;

    private bool ballonCreated = false;

    void Update()
    {
        if (!ballonCreated && nbBallonRestant <= 9)
        {
            ballonCreated = true;
            nbBallonRestant++;
            ApparaitreBallon();
        }
    }

    public void ApparaitreBallon()
    {
        // faire en sorte que le ballon apparaîsse aléatoirement en Y au début 
        nbAleatoireEnYDebut = Random.Range(-8.2f, 4.2f);
        departEnY = nbAleatoireEnYDebut;
        departEnX = 8;
        gameObject.transform.position = new Vector2(departEnX, departEnY);

        // Instancier un nouveau ballon à la position de départ
        GameObject nouveauBallon = Instantiate(ballonPrefab, new Vector2(8, departEnY), Quaternion.identity);
    }

    public void CreateNewBallon()
    {
        ballonCreated = false;
    }
}
