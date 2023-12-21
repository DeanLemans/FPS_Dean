using UnityEngine;
using TMPro;

public class scoreCount : MonoBehaviour
{
    // Reference to the TextMeshPro text component
    public TextMeshProUGUI npcCountText;

    void Start()
    {
        // Check if TextMeshProUGUI component is assigned
        if (npcCountText == null)
        {
            Debug.LogError("TextMeshProUGUI not assigned to NPCCounter script!");
            return;
        }

        // Get the count of objects with the tag "NPC"
        int npcCount = GameObject.FindGameObjectsWithTag("NPC").Length;

        // Display the count in the TextMeshPro text component
        npcCountText.text = "NPC Count: " + npcCount;
    }
}






