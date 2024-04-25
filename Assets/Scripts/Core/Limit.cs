using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Vitesse de déplacement du joueur

    private const float minY = -4f;
    private const float maxY = 3.6f;

    // Exemple d'utilisation :
    void Update()
    {
        if(!PlayerManagerFoot.game_over){
        // Obtient l'entrée verticale
        float verticalInput = Input.GetAxis("Vertical");

        // Déplace le joueur en fonction de l'entrée verticale et de la vitesse
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime, Space.World);

        // Limite la position du joueur
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
        }
    }
}
