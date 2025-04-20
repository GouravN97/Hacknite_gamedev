using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    // Reference to the clue panels
    public GameObject[] cluePanels;  // CluePage1, CluePage2, CluePage3, CluePage4, CluePage5
    public Image[] clueSlots;        // Image slots where objects will go
    public TextMeshProUGUI[] clueTexts;  // Text to show when the panel is complete

    // Navigation buttons
    public Button nextButton;
    public Button backButton;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add clicked object to the correct clue panel
    public void AddToMenu(GameObject clickedObject, string clueTag)
{
    Debug.Log($"Object clicked: {clickedObject.name}, Clue Tag: {clueTag}");  // Debugging line
    int slotIndex = GetClueSlotIndex(clueTag);  // Find the panel slot index based on the tag

    if (slotIndex >= 0 && slotIndex < cluePanels.Length)
    {
        // Assign the sprite to the slot
        clueSlots[slotIndex].sprite = clickedObject.GetComponent<SpriteRenderer>().sprite;
        clueSlots[slotIndex].gameObject.SetActive(true);  // Show the image in the slot
        CheckPanelCompletion(slotIndex);  // Check if all objects for this panel are collected
    }
    else
    {
        Debug.LogError($"Invalid clueTag '{clueTag}', unable to find a valid slot index.");
    }
}


    // Check if all objects are collected in the panel and show the text
    private void CheckPanelCompletion(int panelIndex)
    {
        bool isCompleted = true;

        // Check the clue slots corresponding to this panel's required objects
        int expectedSlotCount = GetExpectedSlotCountForPanel(panelIndex);

        // Check only the expected slots for each panel
        for (int i = 0; i < expectedSlotCount; i++)
        {
            if (clueSlots[i].sprite == null)
            {
                isCompleted = false;  // Panel is not complete
                break;
            }
        }

        // If all slots are filled, show the text and enable Next button
        if (isCompleted)
        {
            clueTexts[panelIndex].gameObject.SetActive(true);  // Show the clue text
            nextButton.interactable = true;  // Enable Next button
        }
    }

    // Get the index of the correct clue panel based on the clue tag
    private int GetClueSlotIndex(string clueTag)
    {
        switch (clueTag)
        {
            case "Clue1": return 0;  // For CluePage1
            case "Clue2.1": return 1;  // For CluePage2 Slot 1
            case "Clue2.2": return 2;  // For CluePage2 Slot 2
            case "Clue3.1": return 3;  // For CluePage3 Slot 1
            case "Clue3.2": return 4;  // For CluePage3 Slot 2
            case "Clue3.3": return 5;  // For CluePage3 Slot 3
            case "Clue4.1": return 6;  // For CluePage4 Slot 1
            case "Clue4.2": return 7;  // For CluePage4 Slot 2
            case "Clue4.3": return 8;  // For CluePage4 Slot 3
            case "Clue5": return 9;  // For CluePage5
            default: return -1;  // If invalid tag
        }
    }

    // Get the expected number of slots for each panel based on the clue tag
    private int GetExpectedSlotCountForPanel(int panelIndex)
    {
        switch (panelIndex)
        {
            case 0: return 1;  // CluePage1 needs 1 slot
            case 1: return 2;  // CluePage2 needs 2 slots (Clue2.1, Clue2.2)
            case 2: return 3;  // CluePage3 needs 3 slots (Clue3.1, Clue3.2, Clue3.3)
            case 3: return 3;  // CluePage4 needs 3 slots (Clue4.1, Clue4.2, Clue4.3)
            case 4: return 1;  // CluePage5 needs 1 slot
            default: return 0;  // Default case
        }
    }

    // Handle Next and Back button navigation
    public void OnNextButtonClicked()
    {
        int currentPanelIndex = GetCurrentActivePanelIndex();
        if (currentPanelIndex < cluePanels.Length - 1)
        {
            cluePanels[currentPanelIndex].SetActive(false);
            cluePanels[currentPanelIndex + 1].SetActive(true);  // Show next panel
            ShowNavigationButtons(currentPanelIndex + 1);
        }
    }

    public void OnBackButtonClicked()
    {
        int currentPanelIndex = GetCurrentActivePanelIndex();
        if (currentPanelIndex > 0)
        {
            cluePanels[currentPanelIndex].SetActive(false);
            cluePanels[currentPanelIndex - 1].SetActive(true);  // Show previous panel
            ShowNavigationButtons(currentPanelIndex - 1);
        }
    }

    private int GetCurrentActivePanelIndex()
    {
        for (int i = 0; i < cluePanels.Length; i++)
        {
            if (cluePanels[i].activeSelf)
            {
                return i;
            }
        }
        return -1;  // No active panel found
    }

    // Enable/disable Next and Back buttons based on the panel
    private void ShowNavigationButtons(int currentPanelIndex)
    {
        backButton.interactable = currentPanelIndex > 0;
        nextButton.interactable = currentPanelIndex < cluePanels.Length - 1;
    }
}
