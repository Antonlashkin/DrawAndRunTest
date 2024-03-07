using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject winLosePanel;
    [SerializeField] private GameObject Runners;

    private void Over()
    {
        winLosePanel.SetActive(true);
        for (int i = 0; i < Runners.transform.childCount; i++)
        {
            Destroy(Runners.transform.GetChild(i).gameObject);
        }
    }
}
