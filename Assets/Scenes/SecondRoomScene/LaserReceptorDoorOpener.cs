using UnityEngine;

public class LaserReceptorDoorOpener : Receptor
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
            door.Open();
        } else {
            door.Close();
        }

        base.Update();
    }
}
