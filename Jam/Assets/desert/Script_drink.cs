using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_drink : MonoBehaviour
{
    public GameObject messageUI;
    public string sceneName = "SampleScene";
    private bool playerInRange = false;
    private SceneFader sceneFader;

    void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
        messageUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E cliked");
            sceneFader.FadeToScene(sceneName);
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

