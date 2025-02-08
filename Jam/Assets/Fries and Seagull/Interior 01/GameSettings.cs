using UnityEngine;

public static class GameSettings
{
    public static float MasterVolume { get; set; } = 1f;
    public static int TargetFPS { get; set; } = 60;
    public static bool IsFullscreen { get; set; } = true;
    public static void SaveSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
        PlayerPrefs.SetInt("TargetFPS", TargetFPS);
        PlayerPrefs.SetInt("IsFullscreen", IsFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }
    public static void LoadSettings()
    {
        MasterVolume = PlayerPrefs.GetFloat("MasterVolume", MasterVolume);
        TargetFPS = PlayerPrefs.GetInt("TargetFPS", TargetFPS);
        IsFullscreen = PlayerPrefs.GetInt("IsFullscreen", IsFullscreen ? 1 : 0) == 1;
    }
    public static void ApplyGraphicsSettings()
    {
        Screen.fullScreenMode = IsFullscreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
        Application.targetFrameRate = TargetFPS;
        QualitySettings.maxQueuedFrames = 1;
    }
}