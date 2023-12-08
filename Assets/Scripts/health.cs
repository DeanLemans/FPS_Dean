using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
}
