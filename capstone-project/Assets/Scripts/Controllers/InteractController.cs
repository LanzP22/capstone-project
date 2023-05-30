using TMPro;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 2f;
    public LayerMask mask;
    public TextMeshProUGUI interactableObjectText;

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, rayDistance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            
            if (interactable == null)
                return;

            interactableObjectText.text = interactable.promptMessage + "\nPress (E) to interact";

            if (Input.GetKeyDown(KeyCode.E) && !GameState.isPlayerFrozen)
            {
                interactable.Interact();
            }
        }
        else
        {
            interactableObjectText.text = "";
        }
    }
}
