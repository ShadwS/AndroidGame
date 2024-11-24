using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<RoadTurnFoPlayer>(out RoadTurnFoPlayer turn))
            StartCoroutine(Rotate(turn.Angle));
    }

    private IEnumerator Rotate(float turn)
    {
        if (turn == 0)
        {
            while (gameObject.transform.eulerAngles.y > turn)
            {
                if (gameObject.transform.eulerAngles.y < 91)
                {
                    gameObject.transform.Rotate(-transform.up * _speed * Time.deltaTime);
                    yield return new WaitForSeconds(Time.deltaTime);
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            while (gameObject.transform.eulerAngles.y < turn)
            {
                gameObject.transform.Rotate(transform.up * _speed * Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        gameObject.transform.rotation = Quaternion.Euler(0, turn, 0);
    }
}