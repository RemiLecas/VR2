using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public RotationCube[] cubes; // Les cubes faisant partie du puzzle
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
            Debug.Log("Porte bonne !");
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        door.transform.Translate(0, 5, 0);
        Debug.Log("Porte ouverte !");
    }
}
