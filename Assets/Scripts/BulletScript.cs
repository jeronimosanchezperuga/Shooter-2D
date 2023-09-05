using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool useVelocity;

    // Start is called before the first frame update
    void Start()
    {
        if (useVelocity)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!useVelocity)
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
