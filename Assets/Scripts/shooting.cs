using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Camera cam;

    private Ray ray;
    private RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)) 
            {
                if (hit.collider.tag.Equals("NPC")) 
                {
                    Destroy(hit.collider.gameObject);
                }
                else 
                {
                    Debug.Log("not npc");
                }
            }
        }
    }
}
