using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttacked : MonoBehaviour
{
    private enemyMovement enemyMovement;
    private Transform Player;
    public float attackRange = 10f;

    public Material defaultMaterial;
    public Material attackedMaterial;
    private Renderer rend;
    public NavMeshAgent navMeshAgent;
    private bool canMove;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<enemyMovement>();
        rend = GetComponent<Renderer>();
        GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= attackRange)
        {
            rend.sharedMaterial = attackedMaterial;
            enemyMovement.agent.SetDestination(Player.position);
            canMove = true;
            navMeshAgent.speed = 5f;
        }
        else
        {
            rend.sharedMaterial = defaultMaterial;
            if (canMove)
            {
                enemyMovement.newLocation();
            }
            canMove = false;
            navMeshAgent.speed = 3.5f;
        }
    }
}

