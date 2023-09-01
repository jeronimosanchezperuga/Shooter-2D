using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] float circleCheckRadius;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, circleCheckRadius, whatIsGround);

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
        
        if (isGrounded)
        {
            Debug.Log("Suelo");
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
        Debug.Log("No Suelo");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
    Gizmos.DrawWireSphere(transform.position + transform.position, circleCheckRadius);
    }
}
