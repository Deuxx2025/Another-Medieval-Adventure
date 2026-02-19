using System.Collections.Generic;
using UnityEngine;

public class LeaderMovementRecorder : MonoBehaviour
{
    public float recordDistance = 0.1f; // Distance of record

    private List<Vector3> positionHistory = new List<Vector3>(); // List of all movements
    private Vector3 lastRecordedPosition; // Last position

    private void Start()
    {
        lastRecordedPosition = transform.position; // Take Player's actual position
        positionHistory.Add(lastRecordedPosition); // Add position to history
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, lastRecordedPosition); // Distance between new position and the last recorded
       if (distance > recordDistance) // Record only at 0.1 units of distance
        {
            positionHistory.Add(transform.position);
            lastRecordedPosition = transform.position;
        }
    }

    public Vector3 GetPositionAtIndex(int index) // Take the position from a referenced index
    {
        if (index < positionHistory.Count)
            return positionHistory[index];

        return positionHistory[positionHistory.Count - 1];
    }

    public int HistoryCount() // Total records 
    {
        return positionHistory.Count;
    }

}
