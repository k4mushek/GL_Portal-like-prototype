using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeatPuzzleManager : MonoBehaviour
{
    [Header("Piston Setup")]
    public Transform piston;
    public Transform chamberBase;
    public float expansionRate = 0.001f; // How much piston moves per heat unit
    public float targetHeight = 1.5f;

    [Header("Heating")]
    public float currentHeat = 0f;
    public float maxHeat = 1000f;
    public float heatPerSecond = 50f;
    public float heatDecayRate = 5f; // slowly cools off over time

    [Header("UI & Visuals")]
    public TextMeshPro heatText;
    public GameObject door;

    private bool puzzleSolved = false;

    void Update()
    {
        if (puzzleSolved) return;

        // Decay heat over time
        currentHeat -= heatDecayRate * Time.deltaTime;
        currentHeat = Mathf.Clamp(currentHeat, 0f, maxHeat);

        // Move piston based on heat
        float pistonY = currentHeat * expansionRate;
        piston.position = new Vector3(piston.position.x, chamberBase.position.y + pistonY, piston.position.z);

        // Update text
        if (heatText != null)
        {
            heatText.text = $"Heat: {currentHeat:F0} J";
        }

        // Check win condition
        if (piston.position.y >= targetHeight)
        {
            puzzleSolved = true;
            door.SetActive(false);
            Debug.Log("Heat Puzzle Solved");
        }
    }

    public void AddHeat(float intensity)
    {
        currentHeat += heatPerSecond * intensity * Time.deltaTime;
        currentHeat = Mathf.Clamp(currentHeat, 0f, maxHeat);
    }

    public void SetHeatIntencity(float value)
    {
        currentHeat += heatPerSecond * value * Time.deltaTime;
    }
}
