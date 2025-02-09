using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour
{
    public string sceneName = "SampleScene";
    private SceneFader sceneFader;

    public void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GetKey.keyVar.isGetKey)
                sceneFader.FadeToScene(sceneName);
        }
    }
}
