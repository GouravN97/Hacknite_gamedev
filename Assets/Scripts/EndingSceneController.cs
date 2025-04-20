using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndingSceneController : MonoBehaviour
{
    public GameObject slide1;            // Drag the whole GameObject (not just Image)
    public GameObject slide2;            // Same here
    public GameObject theEndText;
    public Button mainMenuButton;
    public AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic?.Play();
        StartCoroutine(PlayEnding());
    }

    IEnumerator PlayEnding()
    {
        // Small delay to let the scene load properly
        yield return new WaitForSeconds(0.1f);

        slide1.SetActive(true);
        slide2.SetActive(false);
        theEndText.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);

        slide1.SetActive(false);
        slide2.SetActive(true);

        yield return new WaitForSeconds(3f);

        theEndText.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("StartingScene");
    }
}
