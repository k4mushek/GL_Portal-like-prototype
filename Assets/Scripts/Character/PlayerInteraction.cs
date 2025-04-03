using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactionMask;
    public KeyCode interactKey = KeyCode.E;
    public TextMeshProUGUI interactText;
    private IInteractable currentInteractable;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactionMask))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactText.gameObject.SetActive(true);
                currentInteractable = interactable;

                if (Input.GetKeyDown(interactKey))
                {
                    currentInteractable.Interact();
                }
                return;
            }
        }

        interactText.gameObject.SetActive(false);
        currentInteractable = null;
    }
}
