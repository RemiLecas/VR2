using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public RotationCube parentCube;

    public InputActionProperty selectAction;

    void Update()
    {
        if (selectAction.action.WasPressedThisFrame())
        {
            RaycastHit hit;
            var ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                parentCube.RotateCubeOnClick();
            }
        }
    }
}
