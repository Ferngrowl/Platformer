using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingReset : MonoBehaviour
{
    public float maxFallSpeed = -10f;
    float initialY;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentVelocity = rb.velocity;
        if (currentVelocity.y < maxFallSpeed)
        {
            currentVelocity.y = maxFallSpeed;
            rb.velocity = currentVelocity;
        }

        if (transform.position.y <= -10)
        {
            transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
        }
    }
}
