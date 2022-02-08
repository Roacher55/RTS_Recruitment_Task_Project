using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsTriggerArena : MonoBehaviour
{
    [SerializeField] Doors doors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            doors.isSelectable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            doors.isSelectable = false;
    }
}
