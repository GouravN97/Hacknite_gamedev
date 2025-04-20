using UnityEngine;
using UnityEngine.SceneManagement;

public class SectorExit : MonoBehaviour
{
    public string nextScene; // which scene to load
    public string exitDirection; // "left" or "right"

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Remember the direction
            SceneTransitionData.lastExitDirection = exitDirection;

            // Load the new scene
            SceneManager.LoadScene(nextScene);
        }
    }
}
