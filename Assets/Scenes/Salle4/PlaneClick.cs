using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public RotationCube parentCube; // Référence au script RotationCube attaché au cube parent

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                parentCube.RotateCubeOnClick(); // Appelle la fonction de rotation sur le script du cube parent
            }
        }
    }
}
