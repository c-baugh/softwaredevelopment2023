using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public Transform target;

    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public KeyCode keybind;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = target.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(target.position.x < bulletTransform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotZ * -1);
        }
        if(target.position.x > bulletTransform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }


    }
}
