using UnityEngine;
using TMPro;

public class ClueManager : MonoBehaviour
{
    public TMP_Text popupText;
    private int totalClues = 10;
    private int collectedClues = 0;

    private static ClueManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep ClueManager alive forever
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }

    public void CollectClue()
    {
        collectedClues++;
        Debug.Log($"Collected Clues: {collectedClues}/{totalClues}");
        ShowPopup($"{collectedClues}/{totalClues} clues collected");

        if (collectedClues == totalClues)
        {
            ShowPopup("🎉 You collected all clues! 🎉");
        }
    }

    private void ShowPopup(string message)
    {
        StopAllCoroutines();
        popupText.text = message;
        popupText.gameObject.SetActive(true);
        StartCoroutine(HidePopupAfterSeconds(3));
    }

    private System.Collections.IEnumerator HidePopupAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        popupText.gameObject.SetActive(false);
    }
}
