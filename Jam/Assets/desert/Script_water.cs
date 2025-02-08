using UnityEngine;

public class Water_level : MonoBehaviour
{
    public Transform player;
    public float fadeDistance = 20f;
    public float maxFadeDistance = 60f;
    private float initialY;

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        
        float distance = Vector3.Distance(player.position, transform.position);
        float alpha = Mathf.InverseLerp(fadeDistance, maxFadeDistance, distance);
        float newY = Mathf.Lerp(initialY, initialY - 5f, alpha);
      
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
