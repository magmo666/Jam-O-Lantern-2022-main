using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10000f;
    public float currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar == null)
        {
            Debug.Log("No health bar assigned.");
            return;
        }
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damageDealt) 
    {
        
        currentHealth -= damageDealt;
        Debug.Log("Player health is now " + currentHealth + ".");

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player died.");
            //Destroy(gameObject);
            //SceneManager.LoadScene("MainMenuScene"); //temporary
        }
    }
}
