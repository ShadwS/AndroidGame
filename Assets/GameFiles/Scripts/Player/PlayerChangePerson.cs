using UnityEngine;

public class PlayerChangePerson : MonoBehaviour
{
    [SerializeField] private GameObject[] _players;

    private int _index = 0;
    private Sounds _sounds;

    private void Awake()
    {
        _players[_index].SetActive(true);
        for (int i = 1; i < _players.Length; i++)
        {
            _players[i].SetActive(false);
        }
    }

    private void Start()
    {
        _sounds = Sounds.Instance;
    }

    public void Change()
    {
        _index++;
        if (_index >= _players.Length)
        {
            _index = _players.Length - 1;
        }
        _players[_index - 1].SetActive(false);
        _players[_index].SetActive(true);

        _sounds.PlayChangePlayer();
    }
}