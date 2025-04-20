using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;

    [Header("Teleport Settings")]
    public string sceneToLoad = ""; // Set this in the Inspector

    void Start()
    {
        animator = GetComponent<Animator>();

        // Teleport to saved position if returning to scene
        if (PlayerPrefs.GetInt("HasReturnPos", 0) == 1)
        {
            string returnScene = PlayerPrefs.GetString("ReturnScene", "");
            string currentScene = SceneManager.GetActiveScene().name;

            if (returnScene == currentScene)
            {
                float x = PlayerPrefs.GetFloat("ReturnX");
                float y = PlayerPrefs.GetFloat("ReturnY");
                transform.position = new Vector3(x, y, transform.position.z);

                // Clear return flag
                PlayerPrefs.SetInt("HasReturnPos", 0);
            }
        }
    }

    void Update()
    {
        // Press K to go to the pre-set scene
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                // Save current position and scene
                PlayerPrefs.SetFloat("ReturnX", transform.position.x);
                PlayerPrefs.SetFloat("ReturnY", transform.position.y);
                PlayerPrefs.SetString("ReturnScene", SceneManager.GetActiveScene().name);
                PlayerPrefs.SetInt("HasReturnPos", 1);
                PlayerPrefs.Save();

                SceneManager.LoadScene(sceneToLoad);
                Debug.Log("Teleporting to scene: " + sceneToLoad);
            }
            else
            {
                Debug.LogWarning("No scene name assigned in 'sceneToLoad'. Please set it in the Inspector.");
            }
        }

        // Movement
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
        else if (Input.GetKey(KeyCode.DownArrow)) moveY = -1f;

        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;

        animator.SetBool("isfront", false);
        animator.SetBool("isback", false);
        animator.SetBool("isleft", false);
        animator.SetBool("isright", false);

        if (moveY > 0) animator.SetBool("isback", true);
        else if (moveY < 0) animator.SetBool("isfront", true);
        else if (moveX > 0) animator.SetBool("isright", true);
        else if (moveX < 0) animator.SetBool("isleft", true);

        Vector3 moveDir = new Vector3(moveX, moveY, 0f).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
