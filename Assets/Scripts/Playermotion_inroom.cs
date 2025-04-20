using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class MultiSpritePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject upObj, downObj, leftObj, rightObj;

    [Header("Scene Settings")]
    public string sceneToLoad = "MainScene";

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Not needed for top-down movement
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Sprite switching
        if (movement.x > 0)
            SetActiveSprite(rightObj);
        else if (movement.x < 0)
            SetActiveSprite(leftObj);
        else if (movement.y > 0)
            SetActiveSprite(upObj);
        else if (movement.y < 0)
            SetActiveSprite(downObj);

        // Scene change
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void FixedUpdate()
    {
        // Move using physics (so collision is handled properly)
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void SetActiveSprite(GameObject active)
    {
        upObj.SetActive(active == upObj);
        downObj.SetActive(active == downObj);
        leftObj.SetActive(active == leftObj);
        rightObj.SetActive(active == rightObj);
    }
}
