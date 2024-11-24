using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected AudioClip _clip;

    protected Sounds _sounds;

    protected void Start()
    {
        _sounds = Sounds.Instance;
    }

    public void Open()
    {
        _animator.SetTrigger("Open");
        _sounds.PlayCheckpoint(_clip);
    }
}