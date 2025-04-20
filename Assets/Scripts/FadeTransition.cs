using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeTransition : MonoBehaviour
{
    public Image fadeImage; // Drag your full-screen black UI Image here in Inspector
    public float fadeDuration = 0.5f;

    void Awake()
    {
        if (fadeImage == null)
            fadeImage = GetComponent<Image>(); // fallback if not assigned in Inspector
    }

    public IEnumerator Flash(System.Action onMidFade)
    {
        // Fade to black
        yield return StartCoroutine(Fade(0f, 1f));

        // Do the action (e.g., switch timeline)
        onMidFade?.Invoke();

        // Fade back in
        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        if (fadeImage == null)
        {
            Debug.LogError("Fade image is not assigned!");
            yield break;
        }

        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = endAlpha;
        fadeImage.color = color;
    }
}
