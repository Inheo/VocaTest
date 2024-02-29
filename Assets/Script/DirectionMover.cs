using UnityEngine;

public class DirectionMover : MonoBehaviour
{
    private float _speed = 0;
    private Vector3 _direction = Vector2.zero;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void Set(float speed, Vector3 direction)
    {
        _speed = speed;
        _direction = direction;
    }
}
