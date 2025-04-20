using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleTrigger : MonoBehaviour
{
    public string endingSceneName = "EndingScene";
    public FadeTransition fadeTransition; // Drag this in the Unity Inspector
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            // Start the fade and go to the ending
            StartCoroutine(fadeTransition.Flash(() =>
            {
                SceneManager.LoadScene(endingSceneName);
            }));
        }
    }
}
