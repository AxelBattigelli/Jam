using UnityEngine;
using UnityEngine.SceneManagement; // Permet de charger les scènes

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string sceneName = "SampleScene"; // Mets ici le nom de la scène à charger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie que c'est bien le joueur
        {
            SceneManager.LoadScene(sceneName); // Change de scène
        }
    }
}