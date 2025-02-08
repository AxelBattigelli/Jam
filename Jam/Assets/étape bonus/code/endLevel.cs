using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour
{
    public string sceneName = "SampleScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GetKey.keyVar.isGetKey)
                SceneManager.LoadScene(sceneName);
        }
    }
}
