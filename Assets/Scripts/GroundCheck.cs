using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float radius = .2f;
    [SerializeField] Transform checkTR;
    public bool isGrounded;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(checkTR.position, radius,whatIsGround);       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkTR.position, radius);
    }
}
