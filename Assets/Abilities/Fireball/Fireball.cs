using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    private int damage = 2;

    public bool onFire = false;
    private float timer;
    public float timeBetween = 5;
    Health health;

    public GameObject particles;
    private GameObject part;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            part = Instantiate(particles,collider.transform);
            //onFire = true;

            health = collider.GetComponent<Health>();
            health.Damage(damage);

            StartCoroutine("MyCoroutine");


        }
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1f);
        health.Damage(damage);

        yield return new WaitForSeconds(1f);
        health.Damage(damage);

        yield return new WaitForSeconds(1f);
        health.Damage(damage);

        yield return new WaitForSeconds(1f);
        health.Damage(damage);

        yield return new WaitForSeconds(1f);
        health.Damage(damage);
        Destroy(part);
    }
}

