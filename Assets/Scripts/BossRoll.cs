using UnityEngine;

public class BossRoll : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 15f;
    [SerializeField] private float bossHealth = 100f;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float knockbackDirection = 1;
    private float distance = 1;
    [SerializeField] private float knockbackStrength = 10f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject Wall;
    [SerializeField] private PlayerMovement player;
    public void takeDamage(float damageAmount)
    {
        bossHealth -= damageAmount;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        InvokeRepeating("roll", 2f, 5f);
        if (bossHealth <= 0)
        {
            Destroy (gameObject);
            Wall.SetActive(true);
            Time.timeScale = 0f; 
            Debug.Log("Boss defeated!");
        }
        float knockbackDirection = Mathf.Sign(player.transform.position.x - transform.position.x);
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
