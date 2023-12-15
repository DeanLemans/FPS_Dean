using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
 
    public void takeDamage(float amount = 0.1f)
    {
      currentHealth -= amount;
      if (currentHealth <= 0)
      {
            SceneManager.LoadScene("death");
      }  
    }
}
