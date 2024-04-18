using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    //init variables
    Rigidbody2D rb;
    Animator anim;

    //movement variables
    public Transform target;            //variable for player to be targeted by the enemy
    public float movSpd = 1;
    bool faceRight = true;

    public int health       //sets the enemy's health to 3 hp
    {
        get;
        set;
    } = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //generate weapon (enemy might be generated with a player weapon)
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            knockback(collision);
        }
    }*/

    private void FixedUpdate()
    {
        transform.LookAt(target.position);
        transform.Translate(new Vector3(movSpd * Time.deltaTime, movSpd * Time.deltaTime, 0));

        float hMove = Input.GetAxis("Horizontal");
        //move animation
        if (hMove < 0 && faceRight)
        {
            rb.transform.Rotate(0f, 180f, 0, Space.Self);
            faceRight = false;
        }
        if (hMove > 0 && !faceRight)
        {
            rb.transform.Rotate(0f, 180f, 0, Space.Self);
            faceRight = true;
        }

        //else
        //anim.SetBool("hWalk",true)
        //if (vMove == 0)
        //anim.SetBool("vWalk",false)
        //else
        //anim.SetBool("vWalk",true)


        //attack        //enemy uses weapon if they have one when player is in range
        //if (player is near && holdWeapon == true)
        //useWeapon()
    }
    // Update is called once per frame
    void Update()
    {
        //movement
        transform.rotation = Quaternion.identity;       //keeps the sprite flat instead of rotating around

        /*if (health <= 0)
        {
            Destroy(gameObject);
            //drop weapon
        }*/
    }

    /*public void knockback(Collision2D collision)
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
    }*/
}

}
