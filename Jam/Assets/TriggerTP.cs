using UnityEngine;
using System.Collections;
using Invector;
using Invector.vCharacterController;

public class InvectorTeleport : MonoBehaviour
{
    public Transform teleportDestination; // Position cible

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<vThirdPersonController>()) // V�rifie si c'est le joueur
        {
            StartCoroutine(TeleportPlayer(other.gameObject));
        }
    }

    IEnumerator TeleportPlayer(GameObject player)
    {
        vThirdPersonController invectorController = player.GetComponent<vThirdPersonController>();
        CharacterController controller = player.GetComponent<CharacterController>();
        Rigidbody rb = player.GetComponent<Rigidbody>();

        invectorController.enabled = false;
        if (controller) controller.enabled = false;
        if (rb)
        {
            rb.isKinematic = true;
            rb.linearVelocity = Vector3.zero;
        }
        yield return new WaitForFixedUpdate();

        player.transform.position = teleportDestination.position;

        yield return new WaitForFixedUpdate();

        if (rb) rb.isKinematic = false;
        if (controller) controller.enabled = true;
        invectorController.enabled = true;
    }
}
