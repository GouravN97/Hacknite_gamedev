using System.Collections;
using UnityEngine;

public class CluePopupUI : MonoBehaviour
{
    public GameObject popupUI;
    public float popupDuration = 3f;

    private bool isPopupShowing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isPopupShowing)
        {
            StartCoroutine(ShowCluePopup());
        }
    }

    IEnumerator ShowCluePopup()
    {
        isPopupShowing = true;
        popupUI.SetActive(true);

        yield return new WaitForSeconds(popupDuration);

        popupUI.SetActive(false);
        isPopupShowing = false;
    }
}
