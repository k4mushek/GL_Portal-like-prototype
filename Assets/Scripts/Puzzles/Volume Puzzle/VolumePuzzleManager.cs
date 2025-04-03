using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumePuzzleManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform piston;
    [SerializeField] private Transform chamberBase;
    [SerializeField] private float baseArea = 0.01f;
    [SerializeField] private GameObject door;
    [SerializeField] private TextMeshPro volumeDisplayText;

    [Header("Target Volume (m³)")]
    public float targetVolume = 0.005f; // 5.0L
    public float volumeTolerance = 0.0001f;

    private bool puzzleSolved = false;

    void Update()
    {
        if (puzzleSolved) return;

        float height = Mathf.Abs(piston.position.y - chamberBase.position.y);
        float volume = baseArea * height;

        volumeDisplayText.text = $"Volume: {(volume * 1000f):F2} L";

        if (Mathf.Abs(volume - targetVolume) <= volumeTolerance)
        {
            puzzleSolved = true;
            door.SetActive(false);
            Debug.Log("Puzzle Solved");
        }
    }
}