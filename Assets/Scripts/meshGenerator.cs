using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void CreateShape() 
    {
        vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(0f, 0f, 1f),
        };

        triangles = new int[] 
        {
            2
        }
    }

    void UpdateMesh() 
    {
    
    }
}
