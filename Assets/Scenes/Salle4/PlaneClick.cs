using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlaneClick : MonoBehaviour, IPointerClickHandler
{
    public RotationCube rotationCube;
    public InputActionReference selectAction;
    public UnityEvent onGrab;
    private XRGrabInteractable _grab;


    private void Awake()
    {
        _grab = GetComponent<XRGrabInteractable>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("Pointed");
        if(selectAction.action.triggered) {

            rotationCube.RotateCubeOnClick();
        }
    }
}