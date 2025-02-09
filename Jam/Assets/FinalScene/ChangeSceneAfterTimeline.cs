using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterTimeline : MonoBehaviour
{
    public string sceneName = "MainMenu";

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
