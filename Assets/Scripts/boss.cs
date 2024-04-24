using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss : MonoBehaviour
{
    //tutorial - www.youtube.com/watch?v=xkz0veVavrM&list=PLbsvRhEyGkKcV2lZDqIScL7_fVfRGA1xF&index=2&ab_channel=Mr.Kaiser

    //init variables
    Rigidbody2D rb;
    Animator anim;
    private SpriteRenderer spriteRenderer;

    //movement variables
    public Transform target;            //variable for player to be targeted by the enemy
    public float movSpd = 1;
    public bool faceRight = true;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    

    private void FixedUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            if (target.position.x > transform.position.x)
            {
                transform.Translate(new Vector3(movSpd * Time.deltaTime, movSpd * Time.deltaTime, 0));
                spriteRenderer.flipX = false;

            }
            else
            {
                transform.Translate(new Vector3(-movSpd * Time.deltaTime, movSpd * Time.deltaTime, 0));
                spriteRenderer.flipX = true;

            }

        }
        else
        {
            if (target.position.x > transform.position.x)
            {
                transform.Translate(new Vector3(movSpd * Time.deltaTime, -movSpd * Time.deltaTime, 0));
                spriteRenderer.flipX = false;

            }
            else
            {
                transform.Translate(new Vector3(-movSpd * Time.deltaTime, -movSpd * Time.deltaTime, 0));
                spriteRenderer.flipX = true;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;       //keeps the sprite flat instead of rotating around
    }
}
