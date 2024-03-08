using Dreamteck.Splines;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Rebuilding : MonoBehaviour
{
    [SerializeField] private RectTransform drowWindow;
    [SerializeField] private GameObject Ground;
    private static List<Vector2> _pointsForRebuilding = new List<Vector2>();
    private List<int> numbers;

    [SerializeField] private float zoneSpawnXSize = 40;
    [SerializeField] private float zoneSpawnYSize = 30;

    public void Rebuild(List<Vector2> _points)
    {
        numbers = new List<int>();

        float sumDistance = 0;
        for (int i = 0; i < _points.Count - 1; i++)
        {
            sumDistance += Vector2.Distance(_points[i], _points[i + 1]);
        }

        float distanceBitwin2Runners = sumDistance / (transform.childCount + 1) * 0.9f;
        float ditanceNow = 0;

        for (int i = 0; i < _points.Count - 1; i++)
        {
            ditanceNow += Vector2.Distance(_points[i], _points[i + 1]);
            if (ditanceNow >= distanceBitwin2Runners)
            {
                numbers.Add(i);
                ditanceNow = 0;
            }
        }
        float leftPos = Screen.width / 2 - drowWindow.rect.width / 2 + drowWindow.localPosition.x;
        float rightPos = Screen.width / 2 + drowWindow.rect.width / 2 + drowWindow.localPosition.x;
        float bottomPos = Screen.height / 2 - drowWindow.rect.height / 2 + drowWindow.localPosition.y;
        float topPos = Screen.height / 2 + drowWindow.rect.height / 2 + drowWindow.localPosition.y;

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector2 _pointsForRebuilding = new Vector2(_points[numbers[i % numbers.Count]].x - leftPos - ((rightPos - leftPos) / 2), _points[numbers[i % numbers.Count]].y - bottomPos - ((topPos - bottomPos) / 2));
            float PosX = _pointsForRebuilding.x / (drowWindow.rect.width / 2) * zoneSpawnXSize;
            float PosZ = _pointsForRebuilding.y / (drowWindow.rect.height / 2) * zoneSpawnYSize - transform.position.z;
            transform.GetChild(i).transform.position = new Vector3(PosX, 0, PosZ);
        }

  
    }

    public void StartRun()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(1).GetComponent<Animator>().Play("Run");
            Ground.GetComponent<SplineFollower>().enabled = true;
        }
    }
}
