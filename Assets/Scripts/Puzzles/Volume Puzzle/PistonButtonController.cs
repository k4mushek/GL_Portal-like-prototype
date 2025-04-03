using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonButtonController : MonoBehaviour, IInteractable
{
    [Header("References")]
    public Transform piston;
    public float moveAmount = 0.05f; // How much the piston moves per press (in meters)

    [Header("Settings")]
    public bool moveUp = true;       // Direction of piston movement

    public void Interact()
    {
        float direction = moveUp ? 1f : -1f;
        piston.position += new Vector3(0f, moveAmount * direction, 0f);

        Debug.Log($"Piston moved {(moveUp ? "up" : "down")} by button.");
    }
}
