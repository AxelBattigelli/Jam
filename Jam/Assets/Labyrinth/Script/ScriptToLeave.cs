using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScriptToLeave : MonoBehaviour
{
    public string sceneName = "NomDeLaScene";
    public GameObject messageUI;

    private bool playerInTrigger = false;

    private void Start()
    {
        if (messageUI != null)
            messageUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            if (messageUI != null)
                messageUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            if (messageUI != null)
                messageUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
