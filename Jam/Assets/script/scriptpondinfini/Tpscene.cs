using UnityEngine;
using UnityEngine.SceneManagement; // Permet de charger les sc�nes

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string sceneName = "SampleScene"; // Mets ici le nom de la sc�ne � charger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie que c'est bien le joueur
        {
            SceneManager.LoadScene(sceneName); // Change de sc�ne
        }
    }
}