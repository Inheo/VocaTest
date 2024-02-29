using UnityEngine;

namespace VacoTest.Command
{
    [System.Serializable]
    public struct MoveCommandData
    {
        public float Speed;
        public float UpdateTime;
        public Vector3 Direction;

        public MoveCommandData(float speed, float updateTime, Vector3 direction)
        {
            Speed = speed;
            UpdateTime = updateTime;
            Direction = direction;
        }
    }
}