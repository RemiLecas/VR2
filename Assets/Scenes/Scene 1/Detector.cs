using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEditor.Progress;

public class cubeDetector : MonoBehaviour
{
    public GameObject doorToHide;

    // Start is called before the first frame update
    void Start()
    {
        XRSettings.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("onCollision()");

        GameObject gameObject = collision.gameObject;
        if (gameObject.name == "Key" && gameObject.GetComponent<XRGrabInteractable>())
        {
            Debug.Log("Cube bleu sur Cube rouge !");
            DisableGrab(collision.gameObject);

            if (doorToHide != null)
            {
                doorToHide.SetActive(false); // Désactivez le GameObject de la porte
            }
        }
    }

    void DisableGrab(GameObject obj)
    {
        Debug.Log("DisableGrab()");
        Destroy(obj.GetComponent<XRGrabInteractable>());

        // Disable Kinetic
        var rigidbody = obj.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }
    }
}
