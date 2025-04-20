using UnityEngine;

public class PersistentMenu : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // This makes menu never go away!
    }
}
