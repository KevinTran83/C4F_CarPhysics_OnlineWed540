using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    { 
        GetComponentInParent<CheckpointManager>().NextCheckpoint();
    }
}
