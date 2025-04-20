using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingTrigger : MonoBehaviour
{
    public GameObject infoPopup;
    public string sceneToLoad = "RoomScene";

    private bool playerNear = false;
    private Transform player;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.H))
        {
            if (player != null)
            {
                // Save player position
                PlayerPrefs.SetFloat("ReturnX", player.position.x);
                PlayerPrefs.SetFloat("ReturnY", player.position.y);
                PlayerPrefs.SetInt("HasReturnPos", 1);
            }

            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            infoPopup.SetActive(true);
            playerNear = true;
            player = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            infoPopup.SetActive(false);
            playerNear = false;
        }
    }
}
