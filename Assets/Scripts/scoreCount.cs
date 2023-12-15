using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCount : MonoBehaviour
{
    private void OnDestroy()
    {
        // Find the NPCManager instance in the scene and increment the NPC count
        shooting shooting = FindObjectOfType<shooting>();


        if (shooting != null && gameObject.CompareTag("NPC"))
        {
            shooting.IncrementNPCCount();
        }

        int value = 100;
        Debug.Log($"Value: {value}");
    }
}
