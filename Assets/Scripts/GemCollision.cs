using System.Collections;
using UnityEngine;

public class GemCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ScoreIncriment.Incriment();
            StartCoroutine(DestroyGem());
        }
    }

    private IEnumerator DestroyGem()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
