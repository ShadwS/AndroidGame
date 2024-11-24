using UnityEngine;

public class ClickToStartGame : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMove _player;
    [Space]
    [Header("UI")]
    [SerializeField] private GameObject _canvasStart;
    [SerializeField] private GameObject _canvasRun;

    private void Awake()
    {
        //_canvasStart.SetActive(true);
        //_canvasRun.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            Begin();
    }

    private void Begin()
    {
        _animator.SetTrigger("Start");
        _player.StartGame();
        //_canvasStart.SetActive(false);
        //_canvasRun.SetActive(true);
    }
}