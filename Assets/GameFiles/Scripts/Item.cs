using UnityEngine;

public class Item : MonoBehaviour
{
    public int Value => _point;

    [SerializeField] private int _point;
}