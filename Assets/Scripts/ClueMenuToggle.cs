using UnityEngine;

public class ClueMenuToggle : MonoBehaviour
{
    public GameObject clueMenuPanel; // Assign your clue menu panel in the Inspector

    void Start()
    {
        // Make sure the menu is hidden at the beginning
        clueMenuPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle visibility
            bool isActive = clueMenuPanel.activeSelf;
            clueMenuPanel.SetActive(!isActive);
        }
    }
}
