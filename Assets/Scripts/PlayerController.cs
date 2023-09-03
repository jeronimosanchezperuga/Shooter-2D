using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] GroundCheck groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && groundCheck.isGrounded)
        {
            Saltar();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x < -0.1f)
        {
            transform.eulerAngles = Vector3.up * 180;
        }
        else if (x > 0.1f) 
        {
            transform.eulerAngles = Vector3.zero;
        }

        if (groundCheck.isGrounded)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            anim.SetBool("Jump",false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }
        rb.velocity = new Vector2(x * speed, rb.velocity.y) ;
        
    }

    void Saltar()
    {        
        if (groundCheck.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);            
        }
    }
}
