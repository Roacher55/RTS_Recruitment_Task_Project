using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTriggerArena : MonoBehaviour
{
    [SerializeField] Chest chest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            chest.isSelectable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            chest.isSelectable = false;
    }
}
