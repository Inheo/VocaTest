using UnityEngine;
using VacoTest.Command;

namespace VacoTest.Unit
{
    [CreateAssetMenu]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField, Range(1f, 3f)] private float _minSpeed = 1f;
        [SerializeField, Range(4f, 6f)] private float _maxSpeed = 5f;

        [field: SerializeField] public float UpdateTime { get; private set; } = 1f;

        public MoveCommandData GetMoveCommandData()
        {
            var direction = GetDirection();
            var speed = GetSpeed();
            return new MoveCommandData(speed, UpdateTime, direction);
        }

        private float GetSpeed() => Random.Range(_minSpeed, _maxSpeed);
        private Vector3 GetDirection() => new Vector3(Random.Range(0f, 1f), 0f, Random.Range(0f, 1f)).normalized;
    }
}
