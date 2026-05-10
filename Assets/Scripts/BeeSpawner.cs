using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bee;
    private bool hasSpawned = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasSpawned == false)
            {
                bee.SetActive(true);
                hasSpawned = true;
            }
        }
    }
}
