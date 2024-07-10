using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public RotationCube parentCube;

    public InputActionProperty selectAction;

    private void HandleClick()
    {
        if (selectAction.action.WasPressedThisFrame())
        {
            Debug.Log("here");
            
            parentCube.RotateCubeOnClick();
        }
    }
}
