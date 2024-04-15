using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackArea : MonoBehaviour
{
    private int damage = 5;

    private void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.GetComponent<Health>() != null)
       {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
       }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        knockback(collision);        
    }

    public void knockback(Collision2D collision)
    {
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = collision.collider.bounds.center;

        bool rightHit = contactPoint.x > center.x;
        bool leftHit = contactPoint.x < center.x;
        bool topHit = contactPoint.y > center.y;
        bool bottomHit = contactPoint.y < center.y;

        if (rightHit)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 5, ForceMode2D.Force);
        }
        if (leftHit)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5, ForceMode2D.Force);
        }
        if (topHit)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * 5, ForceMode2D.Force);
        }
        if (bottomHit)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Force);
        }
    }

}
