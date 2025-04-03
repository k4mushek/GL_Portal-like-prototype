using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform cameraTransform;

    private CharacterController controller;
    private float verticalVelocity;
    private float gravity = -9.81f;
    private float cameraPitch = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        verticalVelocity += gravity * Time.deltaTime;
        move.y = verticalVelocity;

        controller.Move(move * moveSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
