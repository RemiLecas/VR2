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
        // Activez l'action lorsque le script est activé
        selectAction.action.Enable();
    }

    void OnDisable()
    {
        // Désactivez l'action lorsque le script est désactivé
        selectAction.action.Disable();
    }

    void Update()
    {
        // Vérifiez si l'action de sélection a été déclenchée cette frame
        if (selectAction.action.triggered)
        {
            // Lancez un raycast depuis la position de la caméra vers la direction de la souris
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            // Si le raycast touche un objet
            if (Physics.Raycast(ray, out hit))
            {
                // Vérifiez si l'objet touché est celui que nous voulons
                if (hit.collider.gameObject == rotationCube.gameObject)
                {
                    rotationCube.RotateCubeOnClick();
                }
            }
        }
    }
}
