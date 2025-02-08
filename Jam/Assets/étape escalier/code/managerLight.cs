using UnityEngine;
 
public class LightManager : MonoBehaviour
{
    public static LightManager Instance;
    public int maxLightsOff = 10;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CheckLights()
    {
        int count = 0;
        LightToggle[] allLights = FindObjectsOfType<LightToggle>();

        foreach (LightToggle light in allLights)
        {
            if (!light.GetComponent<Light>().enabled)
                count++;
        }
        GlobalVariables.totalLightsOff = count;
    }

    public static class GlobalVariables
{
    public static int totalLightsOff = 0;
}

}

