using UnityEngine;

public class SettingGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameSettings.LoadSettings();
        GameSettings.ApplyGraphicsSettings();
    }
    public void SetMasterVolume(float volume)
    {
        GameSettings.MasterVolume = Mathf.Clamp(volume, 0f, 1f);
        GameSettings.SaveSettings();
    }
    public void SetTargetFPS(int fps)
    {
        GameSettings.TargetFPS = fps;
        GameSettings.ApplyGraphicsSettings();
        GameSettings.SaveSettings();
    }
    public void SetFullScreen()
    {
        if (GameSettings.IsFullscreen == true)
        {
            GameSettings.IsFullscreen = false;
        } else
        {
            GameSettings.IsFullscreen = true;
        }
        Screen.fullScreenMode = GameSettings.IsFullscreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
        GameSettings.SaveSettings();
    }
}
