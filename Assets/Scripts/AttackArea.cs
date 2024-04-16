using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackArea : MonoBehaviour
{
    private int damage = 5;

    ////private Camera mainCam;
    ////private Vector3 mousePos;

    void Start()
    {
        //mainCam = GameObject.FindObjectOfType<Camera>();
    }

    void Update()
    {
        /*mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);*/
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }



}
