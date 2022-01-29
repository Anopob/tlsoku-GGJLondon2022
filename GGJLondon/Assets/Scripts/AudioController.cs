using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip _mainMenuTheme, _gameplayTheme, _buttonClickClip, _invalidMoveClip;
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
            PlayMainMenuMusic();
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

    public void PlayMainMenuMusic()
    {
        PlayMusicIfNotAlready(_mainMenuTheme);
    }

    public void PlayGameplayMusic()
    {
        PlayMusicIfNotAlready(_gameplayTheme);
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

    private void PlayMusicIfNotAlready(AudioClip clip)
    {
        if (_musicSource.clip != clip)
        {
            _musicSource.clip = clip;
            _musicSource.Play();
        }
    }
}
