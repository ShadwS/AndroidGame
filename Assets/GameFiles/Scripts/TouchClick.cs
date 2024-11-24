using UnityEngine;
using UnityEngine.EventSystems;

public class TouchClick : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private PlayerRotate _player;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                _player.TurnRight();
            }
            else
            {
                _player.TurnLeft();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _player.TurnIdentity();
    }
}