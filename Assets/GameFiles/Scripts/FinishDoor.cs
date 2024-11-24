using UnityEngine;

public class FinishDoor : Checkpoint
{
    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger("Open");
        _sounds.PlayCheckpoint(_clip);
    }
}