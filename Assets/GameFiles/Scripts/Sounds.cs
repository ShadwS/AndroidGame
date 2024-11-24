using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clipMoney;
    [SerializeField] private AudioClip _clipBottle;
    [SerializeField] private AudioClip _clipChangePlayer;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayCoin()
    {
        _audioSource.clip = _clipMoney;
        _audioSource.Play();
    }

    public void PlayBottle()
    {
        _audioSource.clip = _clipBottle;
        _audioSource.Play();
    }

    public void PlayCheckpoint(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PlayChangePlayer()
    {
        _audioSource.clip = _clipChangePlayer;
        _audioSource.Play();
    }
}