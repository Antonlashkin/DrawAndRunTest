using UnityEngine;

public class GemCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ScoreIncriment.Incriment();
            Destroy(gameObject);
        }
    }
}
