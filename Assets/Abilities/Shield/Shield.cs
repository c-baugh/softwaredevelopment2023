using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public KeyCode keybind;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetKeyDown(keybind) && canFire)
        {
            player.GetComponent<Health>().UseHealing();

        }
    }
}
