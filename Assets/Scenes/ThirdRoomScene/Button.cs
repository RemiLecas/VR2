using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Button : MonoBehaviour
{
    public UnityEvent onGrab;
    private XRGrabInteractable _grab;

    private void Awake()
    {
        _grab = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        Debug.Log(_grab);
        if (_grab.isSelected) {
            Debug.Log("Grabbed");
            onGrab?.Invoke();
        }
    }
}
