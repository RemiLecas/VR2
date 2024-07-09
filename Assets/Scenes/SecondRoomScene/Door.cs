using UnityEngine;

public class Door : MonoBehaviour
{

    private Vector3 _initialPosition;
    public Vector3 maxOffset;
    public float offset;

    public void Awake()
    {
        _initialPosition = transform.position;
    }

    public void Open()
    {
        if (transform.position.x * transform.forward.x <= (_initialPosition.x + maxOffset.x) * transform.forward.x
            && transform.position.y * transform.forward.y <= (_initialPosition.y + maxOffset.y) * transform.forward.y
            && transform.position.z * transform.forward.z <= (_initialPosition.z + maxOffset.z) * transform.forward.z)
        {
            transform.position += transform.forward * offset;
        }
    }

    public void Close()
    {
        if (transform.position.x * transform.forward.x >= _initialPosition.x * transform.forward.x
            && transform.position.y * transform.forward.y >= _initialPosition.y * transform.forward.y
            && transform.position.z * transform.forward.z >= _initialPosition.z * transform.forward.z)
        {
            transform.position -= transform.forward * offset;
        }
    }
}
