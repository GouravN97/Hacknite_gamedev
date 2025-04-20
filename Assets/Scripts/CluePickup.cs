using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CluePickup : MonoBehaviour{
    public Transform clueMenuParent; // Drag CluePage1 here
    public Camera mainCamera;
    private List<Image> clueSlots = new List<Image>();

    void Start()
    {
        // Find all Image components under clueMenuParent
        clueSlots.AddRange(clueMenuParent.GetComponentsInChildren<Image>());
    }

    void Update(){
    if (Input.GetMouseButtonDown(1)) // Right-click
    {
        Debug.Log("Update is running");

    if (Input.GetMouseButtonDown(1)) {
        Debug.Log("Right-click detected");

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject clickedObject = hit.collider.gameObject;
            Debug.Log("Hit: " + clickedObject.name);

            if (clickedObject.CompareTag("Clue"))
            {
                Debug.Log("It's a clue!");

                Sprite clueSprite = clickedObject.GetComponent<SpriteRenderer>().sprite;
                AddToMenu(clueSprite);
                Destroy(clickedObject);
            }
        }
        else
        {
            Debug.Log("No collider hit.");
        }
    }
}

    void AddToMenu(Sprite clueSprite)
    {
        foreach (Image slot in clueSlots)
        {
            if (slot.sprite == null)
            {
                slot.sprite = clueSprite;
                slot.color = Color.white; // Ensure it’s visible
                break;
            }
        }
    }
}
}
