using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToggle : MonoBehaviour
{
    private static MenuToggle instance;
    private bool isMenuOpen = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isMenuOpen)
            {
                SceneManager.LoadScene("MenuOverlay", LoadSceneMode.Additive);
                isMenuOpen = true;
            }
            else
            {
                SceneManager.UnloadSceneAsync("MenuOverlay");
                isMenuOpen = false;
            }
        }
    }
}
