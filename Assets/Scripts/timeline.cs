using UnityEngine;
using System.Collections;

public class TimelineManager : MonoBehaviour
{
    public GameObject presentBG;
    public GameObject pastBG;
    public GameObject presentBuildings;
    public GameObject pastBuildings;

    public GameObject pastground;
    public GameObject presentground;

    public GameObject pastscenery;
    public GameObject presentscenery;

    private bool isPast = false;

    private FadeTransition fade;

    void Start()
    {
        fade = Object.FindFirstObjectByType<FadeTransition>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (fade != null)
                StartCoroutine(fade.Flash(SwitchTimeline));
            else
                Debug.LogWarning("FadeTransition not found!");
        }
    }

    void SwitchTimeline()
    {
        isPast = !isPast;

        if (presentBG != null) presentBG.SetActive(!isPast);
        if (pastBG != null) pastBG.SetActive(isPast);
        if (presentBuildings != null) presentBuildings.SetActive(!isPast);
        if (pastBuildings != null) pastBuildings.SetActive(isPast);
        if (pastground !=null) pastground.SetActive(isPast);
        if (presentground !=null) presentground.SetActive(!isPast);
        if (pastscenery !=null) pastscenery.SetActive(isPast);
        if (presentscenery !=null) presentscenery.SetActive(!isPast);
    }
}
