using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    //tutorial - www.youtube.com/watch?v=xkz0veVavrM&list=PLbsvRhEyGkKcV2lZDqIScL7_fVfRGA1xF&index=2&ab_channel=Mr.Kaiser
    
    //init variables
    Rigidbody2D rb;
    //Animator anim;
    
    //movement variables
    public Transform target;            //variable for player to be targeted by the enemy
    public float movSpd = 1;

    public int health       //sets the enemy's health to 3 hp
    {
        get;
        set;
    } = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //generate weapon (enemy might be generated with a player weapon
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        knockback(transform);           //temp code for demonstration purposes
        /*if (collision.gameObject.tag == Player)
        {
            knockback(target);          //knocks back the player if enemy moves into them
        }
        if (collision.gameObject.tag == Weapon)       //temp code for damage and knockback
        {
            knockback(transform);       //knocks back the enemy when attacked
        }*/
    }

    private void FixedUpdate()
    {
        //movement
        transform.LookAt(target.position);
        transform.Translate(new Vector3(movSpd * Time.deltaTime, 0, 0));
        

        //move animation
        //if (hMove == 0)
            //anim.SetBool("hWalk",false)
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
        if (health <= 0)
        {
            Destroy(gameObject);
            //drop weapon
        }
    }

    public void knockback(Transform attacked)
    {
        rb.AddForce(Vector2.right * 5000, ForceMode2D.Force);           //temp code for demonstration purposes
        /*if (rightHit)
        {
            attacked.AddForce(Vector2.left * 5000, ForceMode2D.Force);
        }
        if (leftHit)
        {
            attacked.AddForce(Vector2.right * 5000, ForceMode2D.Force);
        }
        if (topHit)
        {
            attacked.AddForce(Vector2.down * 5000, ForceMode2D.Force);
        }
        if (bottomHit)
        {
            attacked.AddForce(Vector2.up * 5000, ForceMode2D.Force);
        }*/
        health--;
    }
}
