using UnityEngine;

public class GetKey : MonoBehaviour
{
    public float range = 2f;
    private Transform player;

    private bool isTrue = false;

    public GameObject key;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrue = true;
        }
    }

    void Update()
    {
    if (isTrue && Input.GetKeyDown(KeyCode.F)) {
        Destroy(key);
        keyVar.isGetKey = true;
        }
    }
    public static class keyVar
    {
        public static bool isGetKey = false;
    }
}
