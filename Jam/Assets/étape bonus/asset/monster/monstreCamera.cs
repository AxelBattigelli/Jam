using UnityEngine;

public class MonsterCameraFollow : MonoBehaviour
{
    public Transform monster;
    public Vector3 offset = new Vector3(0, 2.5f, -1.5f);
    public Vector3 rotationOffset = new Vector3(15f, 180f, 0f);

    void LateUpdate()
    {
        if (monster != null)
        {
            transform.position = monster.position + monster.TransformDirection(offset);
            transform.LookAt(monster.position + Vector3.up * 1.2f);
            transform.rotation *= Quaternion.Euler(rotationOffset);
        }
    }
}
