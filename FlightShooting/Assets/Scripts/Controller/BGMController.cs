using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _bgmClipList;
    [SerializeField] private AudioSource _audioSource;

    public void ChangeBGM(EBGM bgm)
    {
        _audioSource.Stop();

        _audioSource.clip = _bgmClipList[(int)(bgm)];
        _audioSource.Play();
    }
}
