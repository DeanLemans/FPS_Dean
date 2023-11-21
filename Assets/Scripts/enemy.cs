using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent monkeyShit;
    void Start()
    {
        monkeyShit.SetDestination(new Vector3(20f, 0f, 5f));
    }

    void Update()
    {
        
    }
    
}
