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

            if (!interactable.interactable)
            {
                interactableObjectText.text = "";
                return;
            }

            interactableObjectText.text = interactable.promptMessage + "\nLeft click to interact";

            if (Input.GetMouseButtonDown(0) && !GameState.isPlayerFrozen)
                interactable.BaseInteract();
        }
        else
        {
            interactableObjectText.text = "";
        }
    }
}
