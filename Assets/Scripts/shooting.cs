using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Camera cam;
    public NPCCounter npcCounter; // Reference to the NPCCounter script

    void Start()
    {
        // Ensure there's a reference to the NPCCounter component
        if (npcCounter == null)
        {
            Debug.LogError("NPCCounter component not assigned to shooting script!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("NPC"))
                {
                    Destroy(hit.collider.gameObject);

                    // Update NPC count after destruction
                    if (npcCounter != null)
                    {
                        npcCounter.UpdateNPCCount();
                    }
                }
            }
        }
    }
}
