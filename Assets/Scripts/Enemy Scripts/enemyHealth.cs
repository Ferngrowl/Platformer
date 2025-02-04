using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    public GameObject enemyDeathEffect;

    public Slider enemyHealthBar;

    public bool drops;
    public GameObject theDrop;

    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthBar.maxValue = currentHealth;
        enemyHealthBar.value = currentHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        enemyHealthBar.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthBar.value = currentHealth;
        if (currentHealth <= 0) 
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(enemyDeathEffect, transform.position,transform.rotation);
        if(drops)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }
}
