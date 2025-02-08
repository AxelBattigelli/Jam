using UnityEditor;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public void Exit()
    {
        GameSettings.SaveSettings();
        if (Application.isEditor)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}