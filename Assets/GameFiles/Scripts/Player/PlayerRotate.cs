using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateAngle;

    private bool _isTurn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<RoadTurnFoPlayer>(out RoadTurnFoPlayer turn))
            StartCoroutine(Rotate(turn.Angle, turn.Checkpoint));
    }

    public void TurnLeft()
    {
        _isTurn = true;
        StartCoroutine(Turn(-1));
    }

    public void TurnRight()
    {
        _isTurn = true;
        StartCoroutine(Turn(1));
    }

    public void TurnIdentity()
    {
        _isTurn = false;
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private IEnumerator Rotate(float turn, Checkpoint checkpoint)
    {
        checkpoint.Open();

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

    private IEnumerator Turn(int direction)
    {
        while (_isTurn)
        {
            gameObject.transform.Rotate(Vector3.up * _speed * direction * Time.deltaTime);
            if (gameObject.transform.rotation.eulerAngles.y >= _rotateAngle)
            {
                break;
            }
            else if(gameObject.transform.rotation.eulerAngles.y <= 360 - _rotateAngle)
            {
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}