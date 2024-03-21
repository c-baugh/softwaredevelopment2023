using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpd;
    float spdX, spdY;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        spdX = Input.GetAxisRaw("Horizontal") * movSpd;
        spdY = Input.GetAxisRaw("Vertical") * movSpd;
        rb.velocity = new Vector2(spdX, spdY);

    }
}
