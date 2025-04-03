using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressurePuzzleManager : MonoBehaviour
{
    [Header("Pressure Settings")]
    public float currentPressure = 100000f;
    public float targetPressure = 200000f;
    public float pressureTolerance = 500f;
    public float pressureDecayRate = 500f;
    public float minPressure = 100000f; 
    public float maxPressure = 200000f;

    [Header("Piston Control")]
    public Transform piston;
    public Vector3 minLocalPosOffset = new Vector3(0f, 0.2f, 0f);
    public Vector3 maxLocalPosOffset = new Vector3(0f, -0.2f, 0f);
    private Vector3 initialLocalPosition;

    [Header("References")]
    public GameObject door;
    public TextMeshPro pressureDisplay;

    private bool puzzleSolved = false;

    private void Start()
    {
        initialLocalPosition = piston.localPosition;
    }
    void Update()
    {
        if (puzzleSolved) return;

        currentPressure -= pressureDecayRate * Time.deltaTime;
        currentPressure = Mathf.Clamp(currentPressure, minPressure, maxPressure);

        pressureDisplay.text = $"Pressure: {(currentPressure / 1000f):F1} kPa";

        // Calculate interpolation factor based on current pressure
        float t = Mathf.InverseLerp(minPressure, maxPressure, currentPressure);

        // Calculate target local position
        Vector3 minPos = initialLocalPosition + minLocalPosOffset;
        Vector3 maxPos = initialLocalPosition + maxLocalPosOffset;
        piston.localPosition = Vector3.Lerp(minPos, maxPos, t);

        if (Mathf.Abs(currentPressure - targetPressure) <= pressureTolerance)
        {
            puzzleSolved = true;
            door.SetActive(false);
            Debug.Log("Pressure Puzzle Solved");
        }
    }

    public void PumpPressure(float amount)
    {
        if (puzzleSolved) return;

        currentPressure += amount;
        currentPressure = Mathf.Clamp(currentPressure, minPressure, maxPressure);
        Debug.Log($"Pressure: {(currentPressure / 1000f):F1} kPa");
    }
}