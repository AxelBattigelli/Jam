using UnityEngine;

public class LightToggle : MonoBehaviour
{
    public float range = 1f;
    private Light pointLight;
    private Transform player;

    void Start()
    {
        
        pointLight = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(transform.position, player.position) <= range)
        {
            pointLight.enabled = !pointLight.enabled;
            LightManager.Instance.CheckLights();
            print(LightManager.GlobalVariables.totalLightsOff);
        }
    }
}
