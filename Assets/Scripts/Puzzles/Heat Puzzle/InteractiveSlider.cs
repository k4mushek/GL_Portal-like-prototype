using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSlider : MonoBehaviour, IInteractable
{
    public Transform sliderHandle;
    public Transform sliderTop;
    public Transform sliderBottom;
    public HeatPuzzleManager puzzleManager;

    [Header("Slider Settings")]
    public float moveSpeed = 0.5f;
    public bool moveUpOnInteract = true;
    private float sliderValue = 0f;
    private bool isInteract = false;

    void Update()
    {
        if (isInteract)
        {
            sliderValue += moveSpeed * Time.deltaTime;
            sliderValue = Mathf.Clamp01(sliderValue);

            sliderHandle.position = Vector3.Lerp(sliderBottom.position, sliderTop.position, sliderValue);
        }

        puzzleManager.SetHeatIntencity(sliderValue);
    }

    public void Interact()
    {
        isInteract = !isInteract;
        Debug.Log("Interacting with slider" + isInteract);
    }
}
