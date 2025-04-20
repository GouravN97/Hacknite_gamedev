using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform leftSpawnPoint; // where to appear if came from right
    public Transform rightSpawnPoint; // where to appear if came from left

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            if (SceneTransitionData.lastExitDirection == "right")
            {
                player.transform.position = leftSpawnPoint.position;
            }
            else if (SceneTransitionData.lastExitDirection == "left")
            {
                player.transform.position = rightSpawnPoint.position;
            }
        }
    }
}
