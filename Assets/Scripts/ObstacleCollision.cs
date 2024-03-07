using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
