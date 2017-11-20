using UnityEngine;
using UnityEditor;
using System;

public class FlipSoundManager : MonoBehaviour, IFlipSoundManager
{
    [SerializeField]
    private AudioClip _flipSoundClip;

    [SerializeField]
    private AudioSource _flipSoundSource;

    #region MonoBehaviour members

    private void Start()
    {
        _flipSoundSource = GetComponent<AudioSource>();
        _flipSoundSource.clip = _flipSoundClip;
    }

    #endregion

    #region IFlipSoundManager members

    public void Play()
    {
        _flipSoundSource.Play();
    }

    #endregion
}