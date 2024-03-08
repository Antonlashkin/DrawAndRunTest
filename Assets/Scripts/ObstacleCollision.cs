using System.Collections;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetChild(2).gameObject.SetActive(true);
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.transform.GetChild(1).gameObject.SetActive(false);
            other.transform.SetParent(transform.parent);
            RunnerDeath(other);
        }
    }

    private IEnumerator RunnerDeath(Collider other)
    {
        yield return new WaitForSeconds(2);
        Destroy(other.gameObject);
    }
}
