using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject door;
    public RotationCube[] cubes;

    private bool puzzleSolved;

    void Awake()
    {
        Instance = this;
    }

    public void CheckCubes()
    {
        foreach (var cube in cubes)
        {
            if (!cube.IsCorrectlyRotated())
            {
                return;
            }
        }

        OpenDoor();
    }

    void OpenDoor()
    {
        if (!puzzleSolved)
        {
            puzzleSolved = true;
            // Code pour ouvrir la porte, par exemple en déplaçant le cube de la porte
            door.transform.Translate(0, 3, 0); // Déplace la porte vers le haut de 5 unités
        }
    }
}
