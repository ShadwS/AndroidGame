using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private PlayerChangePerson _player;
    [SerializeField] private int[] _levels;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _particleSystem;

    private int _score;
    private int _currentLevel;
    private Sounds _sounds;

    private void Start()
    {
        _score = 0;
        _currentLevel = 0;
        _text.text = _score.ToString();

        _sounds = Sounds.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out Item score))
        {
            if (score.Value > 0)
            {
                _sounds.PlayCoin();
            }
            else
            {
                _sounds.PlayBottle();
            }

            _score += score.Value;
            if (_score < 0)
            {
                _score = 0;
            }
            _text.text = _score.ToString();
            var particle = Instantiate(_particleSystem, other.gameObject.transform.position, Quaternion.identity);
            Destroy(particle, 2);
            other.gameObject.SetActive(false);

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