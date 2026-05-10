using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private float EnemyHealth = 50;
    [SerializeField] private float EnemyDamage = 25;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFighting attack = other.GetComponent<PlayerFighting>();
            attack.takeDamage(EnemyDamage);
        }
    }
    public void EnemyTakeDamage(float damage)
    {
        EnemyHealth -= damage;
    }
    private void Update()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy has been defeated!");
        }
    }
}
