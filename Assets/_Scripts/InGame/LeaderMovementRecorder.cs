using System.Collections.Generic;
using UnityEngine;

public class LeaderMovementRecorder : MonoBehaviour
{
    public float recordDistance = 0.1f;

    private List<Vector3> positionHistory = new List<Vector3>();
    private Vector3 lastRecordedPosition;

    private void Start()
    {
        lastRecordedPosition = transform.position;
        positionHistory.Add(lastRecordedPosition);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, lastRecordedPosition);
       if (distance > recordDistance)
        {
            positionHistory.Add(transform.position);
            lastRecordedPosition = transform.position;
        }
    }

    public Vector3 GetPositionAtIndex(int index)
    {
        if (index < positionHistory.Count)
            return positionHistory[index];

        return positionHistory[positionHistory.Count - 1];
    }

    public int HistoryCount()
    {
        return positionHistory.Count;
    }

}
