using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private Line _linePrefab;
    [SerializeField] private RectTransform drowWindow;
    [SerializeField] private Rebuilding Runners;
    private Camera _cam;

    private float leftPos;
    private float rightPos;
    private float topPos;
    private float bottomPos;

    public const float resolution = 0.00001f;

    private Line _currentLine;

    private void Start()
    {
        _cam = Camera.main;
        leftPos = Screen.width / 2 - drowWindow.rect.width / 2 + drowWindow.anchoredPosition.x;
        rightPos = Screen.width / 2 + drowWindow.rect.width / 2 + drowWindow.anchoredPosition.x;
        bottomPos = Screen.height / 2 - drowWindow.rect.height / 2 + drowWindow.anchoredPosition.y;
        topPos = Screen.height / 2 + drowWindow.rect.height / 2 + drowWindow.anchoredPosition.y;
    }

    private void Update()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos = ray.origin + ray.direction * 10;

        if (Input.mousePosition.x < rightPos && Input.mousePosition.x > leftPos && Input.mousePosition.y < topPos && Input.mousePosition.y > bottomPos)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity, transform);
            }

            if (Input.GetMouseButton(0))
            {
                _currentLine.SetPosition(mousePos);
            }
            else if (transform.childCount > 0)
            {
                Rebuilding();
            }
        }
        else
        {
            if (transform.childCount > 0)
            {
                Rebuilding();
            }
        }
    }

    private void Rebuilding()
    {
        Runners.StartRun();
        Runners.Rebuild(transform.GetChild(0).GetComponent<Line>().GetPoints());
        transform.GetChild(0).GetComponent<Line>().Clear();
        Destroy(transform.GetChild(0).gameObject);
    }    
}
