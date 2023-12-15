
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InventoryVR : MonoBehaviour
{
    // public GameObject Inventory;
    // public GameObject Anchor;
    bool UIActive;
    public float inputThreshold = 0.1f;

    
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
  

    private void Start()
    {
        // Inventory.SetActive(false);
        // UIActive = false;
    }

    private void Update()
    {
        // InputDevice leftHandCheck = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        // bool leftPrimaryButton;

        // leftHandCheck.IsPressed(InputHelpers.Button.PrimaryButton, out leftPrimaryButton,0.1f);
        // if(leftPrimaryButton){
        //     Debug.Log("12x3");
        // }

        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
        if(isPressed){
            Debug.Log("123");
        }

        // if (OVRInput.GetDown(OVRInput.Button.Four))
        // {
        //     UIActive = !UIActive;
        //     Inventory.SetActive(UIActive);
        // }
        // if (UIActive)
        // {
        //     Inventory.transform.position = Anchor.transform.position;
        //     Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        // }
    }
}