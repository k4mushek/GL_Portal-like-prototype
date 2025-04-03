using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("interacted with " + gameObject.name);
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}