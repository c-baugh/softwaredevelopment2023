using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpd;
    float spdX, spdY;
    Rigidbody2D rb;
    Collider2D col;

    private float activeMoveSpd;
    public float dashSpd;

    public float dashLength = .5f, dashCooldown = 1f;

    public float dashCounter;
    public float dashCoolCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpd = movSpd;

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
      /*  Health health = transform.GetComponent<Health>();
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = collision.collider.bounds.center;
        bool rightHit = contactPoint.x > center.x;
        bool leftHit = contactPoint.x < center.x;
        bool topHit = contactPoint.y > center.y;
        bool bottomHit = contactPoint.y < center.y;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (leftHit)
            {
                rb.AddForce(Vector2.left * 3000, ForceMode2D.Force);
            }
            if (rightHit)
            {
                rb.AddForce(Vector2.right * 3000, ForceMode2D.Force);
            }
            if (bottomHit)
            {
                rb.AddForce(Vector2.down * 3000, ForceMode2D.Force);
            }
            if (topHit)
            {
                rb.AddForce(Vector2.up * 3000, ForceMode2D.Force);
            }
            health.Damage(5);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            if (leftHit)
            {
                rb.AddForce(Vector2.left * 6000, ForceMode2D.Force);
            }
            if (rightHit)
            {
                rb.AddForce(Vector2.right * 6000, ForceMode2D.Force);
            }
            if (bottomHit)
            {
                rb.AddForce(Vector2.down * 6000, ForceMode2D.Force);
            }
            if (topHit)
            {
                rb.AddForce(Vector2.up * 6000, ForceMode2D.Force);
            }
            health.Damage(10);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        spdX = Input.GetAxisRaw("Horizontal") * activeMoveSpd;
        spdY = Input.GetAxisRaw("Vertical") * activeMoveSpd;
        rb.velocity = new Vector2(spdX, spdY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpd = dashSpd;
                dashCounter = dashLength;
                

            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpd = movSpd;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
