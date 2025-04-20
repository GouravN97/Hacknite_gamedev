using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public Sprite clueSprite; // assign clue's image here

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            if (CompareTag("Clue")) // or check GetComponent<ClueItem>().isClue
            {
                ClueMenu.Instance.AddClueToMenu(clueSprite);
                Destroy(gameObject);
            }
        }
    }
}
