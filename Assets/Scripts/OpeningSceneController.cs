using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class OpeningSceneController : MonoBehaviour
{
    public Image introImage;               // Assign the single intro image in Inspector
    public AudioSource backgroundMusic;   // Assign background music in Inspector
    public float delayBeforeSceneLoad = 5f; // How long to wait before switching scenes

    void Start()
    {
        // Hide image at start
        introImage.gameObject.SetActive(false);

        // Play music if assigned
        backgroundMusic?.Play();

        // Start the intro sequence
        StartCoroutine(PlayIntroAndLoadScene());
    }

    IEnumerator PlayIntroAndLoadScene()
    {
        // Show image
        introImage.gameObject.SetActive(true);

        // Wait for the delay duration
        yield return new WaitForSeconds(delayBeforeSceneLoad);

        // Load next scene automatically
        SceneManager.LoadScene("Scene1.1");
    }
}
