using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensivity = 50f;
    [SerializeField] Transform mainCamera;
    [SerializeField] float maxVerticalAngle = 90f;

    float xRotation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseVertical = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;


        transform.Rotate(Vector3.up, mouseHorizontal);

        xRotation -= mouseVertical;
        xRotation = Mathf.Clamp(xRotation, -maxVerticalAngle, maxVerticalAngle);
        mainCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //mainCamera.Rotate(Vector3.right, -mouseVertical);

    }
}
