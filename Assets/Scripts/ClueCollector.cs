using UnityEngine;

public class ClueCollector : MonoBehaviour
{
    private bool isPlayerNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.T))
        {
            ClueManager manager = FindAnyObjectByType<ClueManager>();
            if (manager != null)
            {
                manager.CollectClue();
            }

            gameObject.SetActive(false); // Hide clue after collection
        }
    }
}
