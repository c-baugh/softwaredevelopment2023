using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    Rigidbody2D rb;
    //Animator anim;

    public int health       //sets the enemy's health to 3 hp
    {
        get;
        set;
    } = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //generate weapon
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == Weapon)       //temp code for damage and knockback
        {
            if (rightHit)
            {
                rb.AddForce(Vector2.left * 5000, ForceMode2D.Force);
            }
            if (leftHit)
            {
                rb.AddForce(Vector2.right * 5000, ForceMode2D.Force);
            }
            if (topHit)
            {
                rb.AddForce(Vector2.down * 5000, ForceMode2D.Force);
            }
            if (bottomHit)
            {
                rb.AddForce(Vector2.up * 5000, ForceMode2D.Force);
            }
            health--;
        }*/
    }
    private void FixedUpdate()
    {
        //movement

        //move animation
        //if (hMove == 0)
            //anim.SetBool("hWalk",false)
        //else
            //anim.SetBool("hWalk",true)
        //if (vMove == 0)
            //anim.SetBool("vWalk",false)
        //else
            //anim.SetBool("vWalk",true)


        //attack
        //if (player is near)
            //useWeapon()
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            //drop weapon
        }
    }

    
}
