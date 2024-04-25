using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    public Image healthBar;
    public GameObject deathMessage;
    public bool player = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            healthBar.fillAmount = health / 100f;
        }

        if(health <= 0)
        {

            deathMessage.SetActive(true);
            Die();


            
        }
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Damage Cannot be Negative");
        }

        this.health -= amount;
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Healing Cannot be Negative");
        }

        this.health += amount;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void UseHealing()
    {
        StartCoroutine("MyCoroutineHealing");
    }

    IEnumerator MyCoroutineHealing()
    {
        for (int i = 0; i < 15; i++)
        {
            if (health < 100)
            {
                yield return new WaitForSeconds(.1f);
                health += 1;
            }
        }
    }
}
