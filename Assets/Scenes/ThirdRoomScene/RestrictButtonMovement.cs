using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictButtonMovement : MonoBehaviour
{
    private Transform _defaultTransform;
    public float maxOffset;
    
    void Awake()
    {
        _defaultTransform = transform;
    }

    void Update()
    {
        transform.position = _defaultTransform.position;
        transform.rotation = _defaultTransform.rotation;
    }
}
