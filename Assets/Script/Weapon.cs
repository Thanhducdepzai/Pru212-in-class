using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName = "Default Weapon"; // Tên của vũ khí
    public int damage = 10; // Lượng sát thương
    public float attackRange = 1.0f; // Phạm vi tấn công
    public float attackSpeed = 1.0f; // Tốc độ tấn công (tấn công mỗi giây)
    public AnimatorOverrideController weaponAnimator; // Animation clip cho vũ khí
    public GameObject weaponModel; // Mô hình hoặc sprite của vũ khí
    public int durability = 100; // Độ bền của vũ khí

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
