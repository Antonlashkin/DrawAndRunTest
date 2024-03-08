using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundListener : MonoBehaviour
{
    [SerializeField] private GameObject Runners;
    [SerializeField] private GameObject winLosePanel;
    [SerializeField] private List<GameObject> canons;
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

                        for (int j = 0; j < canons.Count; j++)
                        {
                            canons[j].transform.GetChild(5).gameObject.SetActive(true);
                        }
                    }
                }
                zLast = transform.position.z;
            }
        }
    }

private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < Runners.transform.childCount; i++)
        {
            Runners.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
            Runners.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
            Runners.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(2);
        winLosePanel.SetActive(true);
        for (int i = 0; i < Runners.transform.childCount; i++)
        {
            Destroy(Runners.transform.GetChild(i).gameObject);
        }
    }    
}
