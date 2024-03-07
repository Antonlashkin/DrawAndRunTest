using TMPro;
using UnityEngine;

public class ScoreIncriment : MonoBehaviour
{
    private static Transform score;
    private static int scoreNumber = 0;

    private void Start()
    {
        score = transform;
    }

    public static void Incriment()
    {
        scoreNumber++;
        score.GetComponent<TMP_Text>().text = scoreNumber.ToString();
    }
}
