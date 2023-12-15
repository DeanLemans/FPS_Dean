using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Camera cam;

    private Ray ray;
    private RaycastHit hit;

    public TextMeshProUGUI npcCountText; // Assign this in the inspector
    private int npcCount = 0;

    private void Start()
    {
        UpdateNPCCountText();
    }

    public void IncrementNPCCount()
    {
        npcCount++;
        UpdateNPCCountText();
    }

    private void UpdateNPCCountText()
    {
        if (npcCountText != null)
        {
            npcCountText.text = npcCount.ToString();
        }
    }

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
                    
                }
            }
        }
    }
}
