using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float jumpForce = 0.2f;
    [SerializeField]
    public int maxHealth = 100;
    [SerializeField]
    public int currentHealth;

    private Rigidbody2D rigid;
    private HealthBar healthBar;  
    private float startTime;
    private bool isGameEnded = false;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        startTime = Time.time;

        healthBar = GetComponent<HealthBar>();  
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        else
        {
            Debug.LogError("HealthBar component is missing");
        }
    }

    void Update()
    {
        if (isGameEnded) return;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigid.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            Debug.LogError("HealthBar component is not assigned");
        }

        if (currentHealth <= 0 && !isGameEnded)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        isGameEnded = true;
        Time.timeScale = 0;

        float playTime = Time.time - startTime;
        PlayerPrefs.SetInt("PlayerScore", UI.instance.score);
        PlayerPrefs.SetFloat("PlayTime", playTime);
        PlayerPrefs.Save();

        SceneManager.LoadScene("EndScene");
    }
}
