using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_drink : MonoBehaviour
{
    public GameObject messageUI;
    private bool playerInRange = false;

    void Start()
    {
        messageUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E cliked");
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

