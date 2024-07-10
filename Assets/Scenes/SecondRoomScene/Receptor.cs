using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Receptor: MonoBehaviour
{
    protected bool IsActive;

    public void Update()
    {
        IsActive = false;
    }

    public void Trigger()
    {
        IsActive = true;
    }
}
