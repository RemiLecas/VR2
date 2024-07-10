using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonChange : MonoBehaviour
{

    public GameObject button;
    public UnityEvent onPress;
    GameObject presser;

    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cube bougé PUTAIN !");
        button.transform.localPosition = new Vector3(0, 0, 0);
        presser = other.gameObject;
        onPress.Invoke();
    }
}
