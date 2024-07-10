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
    public AudioClip duckSound;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Awake()
    {
        XRSettings.enabled = true;
        audioSource = GetComponent<AudioSource>();

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
            DisableGrab(collision.gameObject);
            TriggerDuckSound();

            if (doorToHide != null)
            {
                doorToHide.SetActive(false);
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

    void TriggerDuckSound()
    {
        Debug.Log("TriggerDuckSound()");
        audioSource.clip = duckSound;
        audioSource.Play();
    }
}
