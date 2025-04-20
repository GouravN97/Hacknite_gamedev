using UnityEngine;

public class SisterVoiceTrigger : MonoBehaviour
{
    public AudioSource voiceAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!voiceAudio.isPlaying)
            {
                voiceAudio.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (voiceAudio.isPlaying)
            {
                voiceAudio.Stop();
            }
        }
    }
}
