using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    private LineRenderer _renderer;
    private List<Vector3> _points = new List<Vector3>();
    private static List<Vector2> _pointsForRebuilding = new List<Vector2>();

    public void SetPosition(Vector3 pos)
    {
        _renderer = GetComponent<LineRenderer>();

        _points.Add(pos);

       Vector2 positionForRebuiding = Input.mousePosition;
        _pointsForRebuilding.Add(positionForRebuiding);

        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
    }

    public List<Vector2> GetPoints()
    {
        return _pointsForRebuilding;
    }

    public void Clear()
    {
        _points = new List<Vector3>();
        _pointsForRebuilding = new List<Vector2>();
    }
}
