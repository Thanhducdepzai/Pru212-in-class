using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulKnight1 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float speed = 5.0f; 
    public HealthBar healthBar; 

    void Start()
    {
        currentHealth = maxHealth;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDamage(20);
        }

        // Lấy thông tin từ các phím mũi tên
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Tạo vector di chuyển dựa trên thông tin từ các phím mũi tên
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        // Di chuyển nhân vật
        transform.position += movement * speed * Time.deltaTime;

        // Xoay nhân vật theo hướng di chuyển
        if (moveHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Quay đầu sang trái
        }
        else if (moveHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Quay đầu sang phải
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth); // Cập nhật thanh máu
    }
}
