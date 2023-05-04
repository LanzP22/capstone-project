using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 2f;
    public LayerMask mask;
    public TextMeshProUGUI interactableObjectText;

    void Start()
    {

    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, rayDistance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactableObjectText.text = interactable.promptMessage;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.BaseInteract();
                }
            }
        }
        else
        {
            interactableObjectText.text = "";
        }
    }
}
