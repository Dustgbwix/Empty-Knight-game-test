using UnityEngine;

public class BossRoll : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 15f;
    [SerializeField] private float bossHealth = 100f;
    [SerializeField] private float damage = 25f;
    [SerializeField] private Vector2 knockbackDirection;
    [SerializeField] private float knockbackStrength = 10f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject Wall;
    [SerializeField] private PlayerMovement player;
    public void BosstakeDamage(float damageAmount)
    {
        bossHealth -= damageAmount;
    }
    void Start()
    {
        InvokeRepeating("roll", 2f, 1f);
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (bossHealth <= 0)
        {
            Destroy (gameObject);
            Wall.SetActive(false);
            Time.timeScale = 0f; 
            Debug.Log("Boss defeated! you win!");
        }
        knockbackDirection = new Vector2(Mathf.Sign(player.transform.position.x - transform.position.x), 0);
    }
    private void OnCollisionEnter2D(Collision2D others)
    {
        if (others.gameObject.CompareTag("Player"))
        {
            PlayerFighting player = others.gameObject.GetComponent<PlayerFighting>();
             player.takeDamage(damage);
            rb.AddForce(knockbackDirection * knockbackStrength, ForceMode2D.Impulse);
        }
    }
    private void roll()
    {
        float distance = Mathf.Sign(player.transform.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(distance * rollSpeed, rb.linearVelocity.y);
        Invoke("cancelmovement", 3.5f);
    }
    private void cancelmovement()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
