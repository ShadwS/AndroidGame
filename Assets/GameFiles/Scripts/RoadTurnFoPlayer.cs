using UnityEngine;

public class RoadTurnFoPlayer : MonoBehaviour
{
    public float Angle => _angle;

    public Checkpoint Checkpoint;

    [SerializeField] private float _angle;
}