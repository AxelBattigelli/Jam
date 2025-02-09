using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterTimeline : MonoBehaviour
{
    public string sceneName = "SampleScene";

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
