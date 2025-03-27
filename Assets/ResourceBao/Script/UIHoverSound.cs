using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class HoverClickSoundManager : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public List<Button> targetButtons;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

        foreach (Button button in targetButtons)
        {
            // Thêm hiệu ứng Hover
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry hoverEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
            hoverEntry.callback.AddListener((eventData) => PlaySound(hoverSound));
            trigger.triggers.Add(hoverEntry);

            // Thêm hiệu ứng Click
            button.onClick.AddListener(() => PlaySound(clickSound));
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
