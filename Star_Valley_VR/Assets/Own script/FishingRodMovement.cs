using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FishingRodMovement : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    private bool isMoving = false;
    float rotationSpeed = 60;
    Vector3 currentEulerAngles;
    float z;
    public Transform pivotPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);

        if (!isMoving && isPressed) {
            StartMovment();
        }

        else if (isMoving && !isPressed)
        {
            EndMovment();
        }

        else if (isMoving && isPressed)
        {
            UpdateMovment();
        }
    }

    void UpdateMovment()
    {
        z ++;
        currentEulerAngles += new Vector3(0, 0, z) * Time.deltaTime * rotationSpeed;
        pivotPoint.localEulerAngles = currentEulerAngles;
    }

    void EndMovment()
    {
        isMoving = false;
    }

    void StartMovment()
    {
        isMoving = true;
    }
}
