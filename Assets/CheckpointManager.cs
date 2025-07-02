using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public int totalLaps = 3;
    public List<Checkpoint> checkpoints;
    public UnityEvent onRaceFinished;

    private int targetIndex;
    private int laps;

    // @todo Move to different script.
    private float timer; 
    public Text label;

    void Update()
    {
        if (laps > totalLaps) return;
        timer += Time.deltaTime;
        label.text = timer.ToString("F2");
    }

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
        if (targetIndex == 0) laps ++; // Next lap after track completed.
        //Debug.Log(laps); @todo Delete
        if (laps > totalLaps) onRaceFinished.Invoke(); // Finish the race

        // Make next checkpoint appear.
        checkpoints[targetIndex].gameObject.SetActive(false);
        targetIndex++;
        targetIndex %= checkpoints.Count;
        checkpoints[targetIndex].gameObject.SetActive(true);
    }

    public void NewRace()
    {
        laps = 0;
    }
}
