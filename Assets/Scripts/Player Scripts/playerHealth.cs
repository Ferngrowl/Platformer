using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject playerDeathEffect;
    public AudioClip playerHurt;

    float currentHealth;

    playerController controlMovement;

    AudioSource playerAudio;

    //HUD variables
    public Slider healthBar;
    public Image damageScreen;

    bool damaged = false;
    Color damageFlash = new Color(0f, 0f, 0f, 0.5f);
    float smoothColour = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<playerController>();

        //HUD initialisation
        healthBar.maxValue = fullHealth;
        healthBar.value = fullHealth;

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageScreen.color = damageFlash;
        } else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        damaged = false;
    }

    public void addDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }

        damaged = true;
        currentHealth -= damage;
        playerAudio.clip = playerHurt;
        playerAudio.PlayOneShot(playerHurt);

        if (currentHealth <= 0) {
            makeDead();
        }

        healthBar.value = currentHealth;

    }

    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if(currentHealth < fullHealth)
        {
            currentHealth = fullHealth;
        }

        healthBar.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(playerDeathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
