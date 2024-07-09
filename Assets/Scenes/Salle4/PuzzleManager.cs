using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public RotationCube[] cubes;
    public GameObject door;

    private static PuzzleManager instance;
    public static PuzzleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PuzzleManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        instance = this;
        CheckCubes();
    }

    public void CheckCubes()
    {
        float[] correctRotations = { 90f, 360f, 90f };

        bool allCorrect = true;

        for (int i = 0; i < cubes.Length; i++)
        {
            float currentRotation = cubes[i].GetCurrentRotation();
            Debug.Log($"Cube {i + 1} : Rotation actuelle = {currentRotation}, Rotation correcte = {correctRotations[i]}");

            if (Mathf.Abs(currentRotation - correctRotations[i]) > 0.1f)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        StartCoroutine(OpenDoorAnimation());
        Debug.Log("Porte ouverte !");
    }

    IEnumerator OpenDoorAnimation()
    {
        Vector3 startPos = door.transform.position;
        Vector3 endPos = startPos + new Vector3(0, 5, 0);

        float duration = 1.0f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            door.transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        door.transform.position = endPos;
        Debug.Log("Porte ouverte !");
    }
}
