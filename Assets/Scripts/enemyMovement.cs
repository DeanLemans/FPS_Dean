using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float squareOffMovement = 50f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;
    private float xPosistion;
    private float zPosistion;
    private float yPosistion;
    public float closeEnough = 2f;
    void Start()
    {
        xMax = -squareOffMovement;
        xMin = squareOffMovement;
        zMax = -squareOffMovement;
        zMin = squareOffMovement;

        newLocation();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosistion, yPosistion, zPosistion)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        yPosistion = transform.position.y;
        xPosistion = Random.Range(xMin, xMax);
        zPosistion = Random.Range(zMin, zMax);

        agent.SetDestination(new Vector3(xPosistion, yPosistion, zPosistion));
    }
}
