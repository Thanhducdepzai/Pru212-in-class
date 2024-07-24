using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public float tocDo;
    public int doCao;
    public float lucNhay;
    private bool isFacingRight = true;
    private float traiPhai;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        traiPhai = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(traiPhai * tocDo, rb.velocity.y);

        flip();

        anim.SetFloat("move",Mathf.Abs( traiPhai));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        anim.SetBool("jump", rb.velocity.y != 0);


    }

    void flip()
    {
        if(isFacingRight && traiPhai <0 || !isFacingRight && traiPhai >0)
        {
            isFacingRight = !isFacingRight;
            Vector3 kichThuoc = transform.localScale;
            kichThuoc.x = kichThuoc.x * -1;
            transform.localScale = kichThuoc;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * lucNhay, ForceMode2D.Impulse);
    }
}
