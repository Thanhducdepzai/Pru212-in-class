using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private Rigidbody2D rigid;

    [SerializeField]
    private float maxHealth = 3f;
    private float health;

    [SerializeField]
    private FloatingHealthBar healthBar;

    private bool isDead = false;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    void Update()
    {
        rigid.AddForce(Vector3.right * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            gameObject.transform.localScale = scale;
            speed *= -1;
        }
        else if (collision.gameObject.tag == "Player")
        {
            Vector3 contactPoint = collision.GetContact(0).point;
            Vector3 playerPosition = collision.gameObject.transform.position;
            Vector2 relativePosition = new Vector2(contactPoint.x - playerPosition.x, contactPoint.y - playerPosition.y);

            if (relativePosition.x > 0)
            {
                TakeDamage(1); // Enemy takes damage when hit from the front
            }
            else
            {
                moveScript playerScript = collision.gameObject.GetComponent<moveScript>();
                if (playerScript != null)
                {
                    playerScript.TakeDamage(10);
                    if (playerScript.currentHealth <= 0)
                    {
                        UI.instance.EndGame();
                    }
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false); // Set GameObject inactive instead of destroying it
        ScoreScript1.scoreValue += 1; // Tăng điểm khi kẻ địch bị tiêu diệt
        UI.instance.addScore(); // Thêm điểm khi kẻ địch bị tiêu diệt
    }

    internal void InitializeHealth(float maxHealthObj)
    {
        health = maxHealthObj;
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }
    }
}
