using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RotationCube : MonoBehaviour
{
    public Material[] correctMaterials; // Les matériaux corrects pour les faces du cube
    private Renderer cubeRenderer;
    public float rotationDuration = 0.5f; // Durée de la rotation en secondes

    private bool isRotating = false; // Indique si le cube est en train de tourner
    private float currentRotation = 0f; // Garder une trace de la rotation actuelle en degrés

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        currentRotation = transform.localEulerAngles.x; // Initialiser la rotation actuelle
    }

    void Update()
    {
        // Vérifie si le cube est en rotation et s'il est correctement placé
        if (!isRotating && Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                StartCoroutine(RotateCube(90, rotationDuration)); // Tourne de 90 degrés autour de l'axe X
                Debug.Log("Cube bougé !");
            }
        }
    }

    IEnumerator RotateCube(float angle, float inTime)
    {
        isRotating = true;

        // Calculer la nouvelle rotation en veillant à ce qu'elle reste dans les limites de 0 à 360 degrés
        currentRotation = (currentRotation + angle) % 360;

        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(currentRotation, 0, 0);
        float elapsed = 0.0f;

        while (elapsed < inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, elapsed / inTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = toAngle;

        isRotating = false;
        CheckImages();
    }

    void CheckImages()
    {
        PuzzleManager.Instance.CheckCubes();
    }

    public float GetCurrentRotation()
    {
        // Retourne la rotation actuelle autour de l'axe X, en s'assurant qu'elle est entre 0 et 360
        float rotation = transform.localEulerAngles.x;
        if (rotation < 0)
        {
            rotation += 360;
        }
        return rotation;
    }
}
