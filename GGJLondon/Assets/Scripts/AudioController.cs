using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip _mainTheme, _buttonClickClip, _invalidMoveClip, _validMoveClip;
    private static AudioController _instance;
    private static AudioSource _musicSource;
    private static AudioSource _soundSource;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            var audioSources = this.GetComponents<AudioSource>();
            _musicSource = audioSources[0];
            _soundSource = audioSources[1];
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            PlayMainTheme();
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        _musicSource.volume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        _soundSource.volume = volume;
    }

    public void PlayMainTheme()
    {
        PlayMusicIfNotAlready(_mainTheme);
    }

    //public void PlayJumpSound()
    //{
    //    _soundSource.PlayOneShot(_jumpSound);
    //}

    public void PlayButtonClickClip()
    {
        _soundSource.clip = _buttonClickClip;
        _soundSource.Play();
    }

    public void PlayInvalidMoveClip()
    {
        _soundSource.clip = _invalidMoveClip;
        _soundSource.Play();
    }

    public void PlayValidMoveClip()
    {
        _soundSource.clip = _validMoveClip;
        _soundSource.Play();
    }

    private void PlayMusicIfNotAlready(AudioClip clip)
    {
        if (_musicSource.clip != clip)
        {
            _musicSource.clip = clip;
            _musicSource.Play();
        }
    }
}
