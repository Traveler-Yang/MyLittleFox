using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] allAudioSource;

    public AudioSource bgm, levelEndMusic;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(int soundToPlay)
    {
        allAudioSource[soundToPlay].Stop();
        allAudioSource[soundToPlay].Play();
    }

    public void PlayLevelVictory()
    {
        bgm.Stop();
        levelEndMusic.Play();
    }

    public void ButtonAudio()
    {
        bgm.PlayOneShot(allAudioSource[5].clip);
    }
}
