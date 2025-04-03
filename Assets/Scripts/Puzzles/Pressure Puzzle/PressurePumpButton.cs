using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePumpButton : MonoBehaviour, IInteractable
{
    public PressurePuzzleManager puzzleManager;
    public float pressurePerPress = 5000f; // 5 kPa per press

    public void Interact()
    {
        if (puzzleManager != null)
        {
            puzzleManager.PumpPressure(pressurePerPress);
        }
    }
}