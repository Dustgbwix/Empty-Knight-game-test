using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 45f;
    [SerializeField] private float dashspeed = 45f;
    [SerializeField] private GameObject PlayerHitBox;
    private bool dash = false;
    private float direction = 1f;
    private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("the player controlls is a and d for left and right and space to jump and r and q to dash to reset the game.");
    }
    void FixedUpdate()
    {
        if (dash == false)
        {
            float x = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(x, 0);
            rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
        }
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x > 0)
        {
            direction = 1f;
        }
        else if (x < 0)
        {
            direction = -1f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerHitBox.SetActive(true);
            Invoke("hitboxoff", 0.25f);
        } 
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            Invoke("jumplimit", 0.75f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            dash = true;
            rb.linearVelocity = new Vector2(direction * dashspeed, rb.linearVelocity.y);
            Invoke("dashturnoff", 0.25f);
        }
    }
    private void hitboxoff()
    {
        PlayerHitBox.SetActive(false);
    }
    private void jumplimit()
    {
        isGrounded = true;
    }
    private void dashturnoff()
    {
        dash = false;
    }
}
