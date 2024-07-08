using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotationCube : MonoBehaviour
{
    public Material[] correctMaterials; // Les matériaux corrects pour les faces du cube
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                transform.Rotate(90, 0, 0);
                CheckImages();
            }
        }
    }

    void CheckImages()
    {
        if (IsCorrectlyRotated())
        {
            PuzzleManager.Instance.CheckCubes();
        }
    }

    public bool IsCorrectlyRotated()
    {
        Material[] currentMaterials = cubeRenderer.materials;

        for (int i = 0; i < correctMaterials.Length; i++)
        {
            if (currentMaterials[i] != correctMaterials[i])
            {
                return false;
            }
        }
        return true;
    }
}
