using UnityEngine;

public class OrbVictory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("the orb consumes you!");
            Time.timeScale = 0f; 
        }
    }
}
