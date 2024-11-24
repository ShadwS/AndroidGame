using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private PlayerChangePerson _player;
    [SerializeField] private int[] _levels;
    [SerializeField] private TMP_Text _text;

    private int _score;
    private int _currentLevel;

    private void Start()
    {
        _score = 0;
        _currentLevel = 0;
        _text.text = _score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out Item score))
        {
            _score += score.Value;
            if (_score < 0)
            {
                _score = 0;
            }
            _text.text = _score.ToString();
            Destroy(other.gameObject);

            if (_score >= _levels[_currentLevel])
            {
                _currentLevel++;
                if (_currentLevel >= _levels.Length)
                {
                    _currentLevel = _levels.Length - 1;
                }
                _player.Change();
            }
        }
    }
}