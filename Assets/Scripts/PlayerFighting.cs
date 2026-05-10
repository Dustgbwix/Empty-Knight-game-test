using UnityEngine;

public class PlayerFighting : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private float PlayerHealth = 100f;
    [SerializeField] private float AttackDamage = 10f;
    public void takeDamage(float damage)
    {
        PlayerHealth -= damage;
    }
    public void Update()
    {
        if (PlayerHealth <= 0)
        {
            Debug.Log("you died!");
            Time.timeScale = 0f;
        }
    }
    private void onTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyFight enemy = other.GetComponent<EnemyFight>();
            enemy.EnemyTakeDamage(AttackDamage);
            Debug.Log("you hit the enemy!");
        }
    }
}
