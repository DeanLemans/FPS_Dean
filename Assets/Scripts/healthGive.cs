using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthGive : MonoBehaviour
{
    public Health health;

    private void OnCollisionEnter(Collision collision)
    {
        health.currentHealth += 2;
        Destroy(gameObject);
    }
}
