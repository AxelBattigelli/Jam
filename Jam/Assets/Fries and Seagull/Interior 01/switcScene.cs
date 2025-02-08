using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public string scene;
    public void NextScene()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(scene);
    }
}