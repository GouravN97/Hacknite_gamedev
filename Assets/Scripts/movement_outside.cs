using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private float move = 0f;

    public AudioSource runSound; // 🎵 Add this in Inspector

    private enum Direction { Left, Right }
    private Direction lastDirection = Direction.Right;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        move = 0f;

        // Handle input and direction
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
            lastDirection = Direction.Right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
            lastDirection = Direction.Left;
        }

        // Move the player
        transform.Translate(Vector3.right * move * moveSpeed * Time.deltaTime);

        // Handle animation
        if (move > 0)
        {
            animator.SetBool("start_running_right", true);
            animator.SetBool("start_running_left", false);
        }
        else if (move < 0)
        {
            animator.SetBool("start_running_right", false);
            animator.SetBool("start_running_left", true);
        }
        else
        {
            animator.SetBool("start_running_right", false);
            animator.SetBool("start_running_left", false);
        }

        // Handle running sound
        if (move != 0)
        {
            if (!runSound.isPlaying)
                runSound.Play();
        }
        else
        {
            runSound.Stop();
        }
    }
}
