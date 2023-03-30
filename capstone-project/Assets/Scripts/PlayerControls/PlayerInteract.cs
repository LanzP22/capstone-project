using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float range = 1.5f;
    public LayerMask mask;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractButtonPress();
        }
    }   

    void InteractButtonPress()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        // Debug.DrawRay(ray.origin, ray.direction * range);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, range, mask))
        {
            InteractableObject? interactableObject = hitInfo.collider.GetComponent<InteractableObject>();
            interactableObject?.BaseInteract();
        }
    }
}
