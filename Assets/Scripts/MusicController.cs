using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip QuitGameSound;
    public AudioClip PlayGameSound;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void PlayQuitGameSound()
    {
        if (QuitGameSound != null)
        {
            source.PlayOneShot(QuitGameSound);
        }
        else
        {
            Debug.LogError("AudioSource component is missing.");
        }
    }

    public void PlayStartGameSound()
    {
        if (PlayGameSound != null)
        {
            source.PlayOneShot(PlayGameSound);
        }
        else
        {
            Debug.LogError("AudioSource component is missing.");
        }
    }
}