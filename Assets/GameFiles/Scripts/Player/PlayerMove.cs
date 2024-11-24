using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _currentSpeed;

    private void Awake() => _currentSpeed = 0;

    private void Update() => gameObject.transform.Translate(-Vector3.forward * _currentSpeed * Time.deltaTime);

    public void StartGame() => _currentSpeed = _speed;
}