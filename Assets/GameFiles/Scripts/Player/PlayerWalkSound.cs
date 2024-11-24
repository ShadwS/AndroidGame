using UnityEngine;
using System.Collections;

public class PlayerWalkSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    private int _index;

    private void Awake()
    {
        _index = 0;
    }

    private void Start()
    {
        _audioSource.clip = _audioClips[_index];
    }

    public void ChangeAudioClip()
    {
        _index++;
        if (_index >= _audioClips.Length)
        {
            _index = _audioClips.Length - 1;
        }

        _audioSource.clip = _audioClips[_index];
    }

    public void Play() => StartCoroutine(PlayWalk());

    private IEnumerator PlayWalk()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }
        }
    }
}