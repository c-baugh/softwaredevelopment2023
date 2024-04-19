using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpd;
    float spdX, spdY;
    Rigidbody2D rb;

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
