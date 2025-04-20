using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public string clueTag;  // This is used to tag the object (e.g., Clue1, Clue2, etc.)

    void OnMouseDown()  // This function runs when the player clicks the object
    {
        // Tell the MenuManager to add this object to the correct clue panel
        MenuManager.Instance.AddToMenu(this.gameObject, clueTag);
    }
}
