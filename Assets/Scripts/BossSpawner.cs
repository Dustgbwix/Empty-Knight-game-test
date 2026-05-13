using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    private bool hasSpawned = false;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject wall;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasSpawned == false)
            {
                boss.SetActive(true);
                wall.SetActive(true);
                hasSpawned = true;
            }
        }
    }
}
