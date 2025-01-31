using UnityEngine;

public class Laser : MonoBehaviour
{
    private const float MaxLaserDistance = 500;
    private RaycastHit _raycastHit;

    void Update()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        if (!lineRenderer) {
            return;
        }


        if(Physics.Raycast(transform.position, transform.forward, out _raycastHit))
        {
            lineRenderer.SetPosition(1, transform.InverseTransformPoint(_raycastHit.point));
            Receptor receptor = _raycastHit.transform.gameObject.GetComponent<Receptor>();
            if (receptor)
            {
                receptor.Trigger();
            }
        } else {
            lineRenderer.SetPosition(1, transform.position + transform.forward * MaxLaserDistance);
        }
    }
}
