using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public List<AudioClip> audioClips;  // List of audio clips (MP3 files)
    private AudioSource audioSource;
    private int currentClipIndex = 0;
    private bool isPaused = false;
    private bool isMuted = false;
    public KeyCode pausePlayKey = KeyCode.Space;
    public KeyCode nextClipKey = KeyCode.RightArrow;
    public KeyCode previousClipKey = KeyCode.LeftArrow;
    public KeyCode muteKey = KeyCode.M;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(pausePlayKey))
        {
            TogglePause();
        }

        if (Input.GetKeyDown(nextClipKey))
        {
            PlayNextClip();
        }

        if (Input.GetKeyDown(previousClipKey))
        {
            PlayPreviousClip();
        }

        if (Input.GetKeyDown(muteKey))
        {
            ToggleMute();
        }
    }

    void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Count - 1)
        {
            currentClipIndex++;
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            isPaused = false;
        }
    }

    void PlayPreviousClip()
    {
        if (currentClipIndex > 0)
        {
            currentClipIndex--;
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            isPaused = false;
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            audioSource.UnPause();
            isPaused = false;
        }
        else
        {
            audioSource.Pause();
            isPaused = true;
        }
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
    }
}
