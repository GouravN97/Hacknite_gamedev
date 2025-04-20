using UnityEngine;

public class InstructionPopup : MonoBehaviour
{
    public GameObject instructionPanel;
    private bool isVisible = false;

    void Start()
    {
        // Ensure the panel is hidden at start
        instructionPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isVisible = !isVisible;
            instructionPanel.SetActive(isVisible);
        }
    }
}
