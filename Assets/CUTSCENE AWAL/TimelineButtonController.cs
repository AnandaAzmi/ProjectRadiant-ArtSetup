using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class TimelineButtonController : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public Button continueButton;
    public GameObject[] objectsToDisable; // Daftar objek yang akan dinonaktifkan
    private void Start()
    {
        // Pastikan button di-disable saat start
        // continueButton.gameObject.SetActive(false);

        // Tambahkan listener ke button
        continueButton.onClick.AddListener(ResumeTimeline);
    }

    public void ShowButton()
    {
        // Tampilkan button
        continueButton.gameObject.SetActive(true);
    }


    // Fungsi untuk menonaktifkan objek
    public void DisableObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
    private void ResumeTimeline()
    {
        // Lanjutkan Timeline
        if (timelineDirector != null)
        {
            timelineDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
        }

        // Sembunyikan button
        continueButton.gameObject.SetActive(false);
    }

    public void PauseTimeline()
    {
        // Pause Timeline
        if (timelineDirector != null)
        {
            timelineDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
        }

        // Tampilkan button
        ShowButton();
    }
}
