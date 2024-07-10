using UnityEngine;

public class LaserReceptorDoorCloser : Receptor
{
    public GameObject target;

    new void Update()
    {
        Door door = target.GetComponent<Door>();
        if (!door) {
            return;
        }

        if (IsActive)
        {
            door.Close();
        } else {
            door.Open();
        }

        base.Update();
    }
}
