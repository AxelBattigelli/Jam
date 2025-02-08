using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform player; // Le joueur � suivre
    public Vector3 offset = new Vector3(0, 0, 0); // D�calage de la lumi�re

    void Update() // Utilisation de LateUpdate pour �viter des probl�mes de lag
    {
        Debug.Log("Position du joueur : " + transform.position);
        if (player != null)
        {
            transform.position = new Vector3(offset.x, offset.y, player.position.z + 10f); // Suivre la position du joueur
            //Debug.Log("Position Z du joueur: " + player.position.z);
        }
    }
}