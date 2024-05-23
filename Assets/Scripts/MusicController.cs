using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip QuitGameSound;
    public AudioClip PlayGameSound;
    public AudioClip level5;
    public AudioClip level10;
    public AudioClip enemyKill;
    public AudioClip playerDamage;
    public AudioClip fireArrow;
    public AudioClip fireKunai;
    public AudioClip fireSpirit;

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

    public void PlayLevel5()
    {
        source.Stop();
        source.clip = level5;
        source.Play();
    }

    public void PlayLevel10()
    {
        source.Stop();
        source.clip = level10;
        source.Play();
    }

    public void PlayEnemyKill()
    {
        source.PlayOneShot(enemyKill);
    }

    public void PlayPlayerDamage()
    {
        source.PlayOneShot(playerDamage);
    }

    public void PlayFireArrow()
    {
        source.PlayOneShot(fireArrow);
    }

    public void PlayFireSpirit()
    {
        source.PlayOneShot(fireSpirit);
    }

    public void PlayFireKunai()
    {
        source.PlayOneShot(fireKunai);
    }
}
