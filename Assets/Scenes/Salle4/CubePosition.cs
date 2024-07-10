using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePosition : MonoBehaviour
{
    private Transform _defaultTransform;
    public float maxOffset;
    
    void Awake()
    {
        _defaultTransform = transform;
    }

    void LateUpdate()
    {
        transform.position = _defaultTransform.position;
    }
}
