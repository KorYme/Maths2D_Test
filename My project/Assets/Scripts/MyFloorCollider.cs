using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFloorCollider : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<Vector2> _floorPoints;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < _floorPoints.Count - 1; i++)
        {
            Gizmos.DrawLine(_floorPoints[i], _floorPoints[i+1]);
        }
    }

    public bool IsUnderTheFloor(Vector2 position, float radius)
    {
        for (int i = 0; i < _floorPoints.Count - 1; i++)
        {
            if (position.x > _floorPoints[i].x - radius && position.x < _floorPoints[i+1].x + radius
                && Vector2.Distance(_floorPoints[i] + (Vector2)Vector3.Project(position - _floorPoints[i], _floorPoints[i + 1] - _floorPoints[i]), position) <= radius)
            {
                Debug.Log(Vector2.Distance(_floorPoints[i] + (Vector2)Vector3.Project(position - _floorPoints[i], _floorPoints[i + 1] - _floorPoints[i]), position));
                return true;
            }
        }
        return false;
    }
}
