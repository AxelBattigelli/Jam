using UnityEngine;
using UnityEngine.SceneManagement;  // N�cessaire pour charger des sc�nes
using UnityEngine.UI;  // N�cessaire pour manipuler l'UI

public class Script_drink : MonoBehaviour
{
    public GameObject messageUI;  // Le GameObject contenant le texte du message "E pour boire"
    private bool playerInRange = false;  // Pour v�rifier si le joueur est dans la zone du trigger

    void Start()
    {
        // Masquer le message au d�but (avant que le joueur n'entre dans la zone)
        messageUI.SetActive(false);
    }

    void Update()
    {
        // Si le joueur est dans la zone et qu'il appuie sur 'E'
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E cliked");
            // Charger la sc�ne suivante (remplacer "SceneName" par le nom de la sc�ne suivante)
            SceneManager.LoadScene("Labyrinth");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageUI.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageUI.SetActive(false);
            playerInRange = false;
        }
    }

 
    }

