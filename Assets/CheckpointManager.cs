using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;

    private int targetIndex;

    void Start()
    {
        checkpoints = new List<Checkpoint>();
        foreach (Checkpoint c in GetComponentsInChildren<Checkpoint>())
        { 
            checkpoints.Add(c);
        }
        TurnAllOff();
        checkpoints[0].gameObject.SetActive(true);
    }

    void TurnAllOff()
    {
        foreach (Checkpoint c in checkpoints) c.gameObject.SetActive(false);
    }

    public void NextCheckpoint()
    {
        checkpoints[targetIndex].gameObject.SetActive(false);
        targetIndex++;
        targetIndex %= checkpoints.Count;
        checkpoints[targetIndex].gameObject.SetActive(true);
    }
}
