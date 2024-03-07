using UnityEngine;

public class NewRunner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabRuner;
    private GameObject runner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            runner = Instantiate(_prefabRuner, other.transform.parent);
            runner.transform.position = new Vector3(other.transform.position.x, 0, other.transform.position.z + 5);
            runner.transform.GetChild(1).GetComponent<Animator>().Play("Run");
            Destroy(gameObject);
        }
    }
}
