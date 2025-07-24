using System.Collections.Generic;
using UnityEngine;

public enum EBGMType
{
    STAGE = 0,
    BOSS = 1,
}

public class BGMController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _bgmClipList;
    [SerializeField] private AudioSource _audioSource;

    public void ChangeBGM(EBGMType type)
    {
        _audioSource.Stop();

        _audioSource.clip = _bgmClipList[(int)(type)];
        _audioSource.Play();
    }
}
