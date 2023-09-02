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
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            Saltar();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //rb.MovePosition(rb.position + new Vector2(x, y) * speed);
        rb.velocity = new Vector2(x * speed, rb.velocity.y) ;
    }

    void Saltar()
    {
        
        if (groundCheck.isGrounded)
        {
            Debug.Log("Suelo");
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("No Suelo");
        }
    }

}
