using UnityEngine;
using TMPro;

public class NPCCounter : MonoBehaviour
{
    public TextMeshProUGUI npcCountText;

    private void Start()
    {
        UpdateNPCCount();
    }

    void Awake()
    {
        if (npcCountText == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned to NPCCounter script!");
            return;
        }

        UpdateNPCCount();
    }

    // Method to update the NPC count text
    public void UpdateNPCCount()
    {
        int npcCount = GameObject.FindGameObjectsWithTag("NPC").Length;
        npcCountText.text = "enemy Count: " + npcCount;
    }
}