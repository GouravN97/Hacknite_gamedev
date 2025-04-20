using UnityEngine;
using UnityEngine.UI;

public class ClueMenu : MonoBehaviour
{
    public static ClueMenu Instance;

    public Image[] clueSlots; // Drag your 10 square UI Images here in Inspector
    private int nextSlot = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddClueToMenu(Sprite clueSprite)
    {
        if (nextSlot >= clueSlots.Length) return;

        clueSlots[nextSlot].sprite = clueSprite;
        clueSlots[nextSlot].enabled = true;
        nextSlot++;
    }
}
