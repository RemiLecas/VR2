using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RotationCube : MonoBehaviour
{
    public Material[] correctMaterials;
    private Renderer cubeRenderer;
    public float rotationDuration = 0.5f;

    private bool isRotating = false;
    private float currentRotation = 0f;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        currentRotation = transform.localEulerAngles.x;
    }

    public void RotateCubeOnClick()
    {
        Debug.Log("PUTAING");
        if (!isRotating)
        {
            StartCoroutine(RotateCube(90, rotationDuration));
            Debug.Log("Cube boug� !");
        }
    }

    IEnumerator RotateCube(float angle, float inTime)
    {
        isRotating = true;

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
        float rotation = transform.localEulerAngles.x;
        if (rotation < 0)
        {
            rotation += 360;
        }
        return rotation;
    }
}
