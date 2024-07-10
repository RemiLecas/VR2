using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaneClick : MonoBehaviour
{
    public RotationCube rotationCube;
    public InputActionReference selectAction;

    void OnEnable()
    {
        // Activez l'action lorsque le script est activ�
        selectAction.action.Enable();
    }

    void OnDisable()
    {
        // D�sactivez l'action lorsque le script est d�sactiv�
        selectAction.action.Disable();
    }

    void Update()
    {
        // V�rifiez si l'action de s�lection a �t� d�clench�e cette frame
        if (selectAction.action.triggered)
        {
            // Lancez un raycast depuis la position de la cam�ra vers la direction de la souris
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            // Si le raycast touche un objet
            if (Physics.Raycast(ray, out hit))
            {
                // V�rifiez si l'objet touch� est celui que nous voulons
                if (hit.collider.gameObject == rotationCube.gameObject)
                {
                    rotationCube.RotateCubeOnClick();
                }
            }
        }
    }
}
