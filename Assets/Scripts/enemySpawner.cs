using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [Header("Spawner of da enemy's")]
    public GameObject enemyPrefab;
    public int enemyAmount;
    void Start()
    {
        GetComponent<enemySpawner>();
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

}
