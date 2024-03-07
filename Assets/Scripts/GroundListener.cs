using Dreamteck.Splines;
using System.Collections;
using UnityEngine;

public class GroundListener : MonoBehaviour
{
    [SerializeField] private GameObject Runners;
    [SerializeField] private GameObject winLosePanel;
    float zLast;

    void Update()
    {
        if (GetComponent<SplineFollower>().enabled == true)
        {
            if (zLast == 0)
            {
                zLast = transform.position.z;
            }
            else
            {
                if (zLast == transform.position.z)
                {
                    for (int i = 0; i < Runners.transform.childCount; i++)
                    {
                        Runners.transform.GetChild(i).transform.rotation = new Quaternion(0, 90, 0, 0);
                        Runners.transform.GetChild(i).GetChild(1).GetComponent<Animator>().Play("Finish");
                        StartCoroutine(GameOver());
                    }
                }
                zLast = transform.position.z;
            }
        }
    }

private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5);
        winLosePanel.SetActive(true);
        for (int i = 0; i < Runners.transform.childCount; i++)
        {
            Destroy(Runners.transform.GetChild(i).gameObject);
        }
    }    
}
