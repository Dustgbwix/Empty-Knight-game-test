using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private Rigidbody2D rb;
    [SerializeField] private float EnemySpeed = 10f;
    [SerializeField] private float dashlimit = 5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Movebee", 1f, 0.05f);
    }
    private void Movebee()
    {
        if (dashlimit > 0)
        {
            Vector2 direction = (Player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * EnemySpeed * Time.fixedDeltaTime);
            dashlimit -= 1;
        }
        else
        {
            Invoke("Normaldash", 5f);
        }
    }
    private void Normaldash()
    {
        dashlimit = 5f;
    }
}
