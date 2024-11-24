using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Open() => _animator.SetTrigger("Open");
}