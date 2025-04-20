using UnityEngine;

public class PlayerReturnPosition : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("HasReturnPos", 0) == 1)
        {
            float x = PlayerPrefs.GetFloat("ReturnX");
            float y = PlayerPrefs.GetFloat("ReturnY");
            transform.position = new Vector3(x, y, transform.position.z);

            // Clear it after teleporting
            PlayerPrefs.SetInt("HasReturnPos", 0);
        }
    }
}
