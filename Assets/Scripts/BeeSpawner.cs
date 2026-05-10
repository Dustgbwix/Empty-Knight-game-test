using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bee;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bee.SetActive(true);
        }
    }
}
