
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("PLAYER CAMERA")]
    public Camera playerCamera;

    [Header("INTERACTION SETTINGS")]
    public float interactionDistance = 3f;

    void Update()
    {
        // Do nothing while the achievement popup is open
        if (Time.timeScale == 0f)
            return;

        // Check if the player presses E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Cast a ray from the centre of the camera
            Ray ray = new Ray(
                playerCamera.transform.position,
                playerCamera.transform.forward
            );

            RaycastHit hit;

            // Check whether the ray hits an object
            if (Physics.Raycast(
                ray,
                out hit,
                interactionDistance))
            {
                // Check if the object is collectible
                CollectibleItem item =
                    hit.collider.GetComponentInParent
                    <CollectibleItem>();

                // Collect the artefact
                if (item != null)
                {
                    item.Collect();
                }
            }
        }
    }
}
