using System.Collections.Generic;
using UnityEngine;
using VacoTest.Command;

namespace VacoTest
{
    public class Player : Unit
    {
        [SerializeField] private float _updateTime = 1f;

        public override float UpdateTime => _updateTime;

        private List<MoveCommandData> _data = new List<MoveCommandData>();

        protected override void UpdateMover()
        {
            var direction = new Vector3(Random.Range(0f, 1f), 0f, Random.Range(0f, 1f)).normalized;
            var speed = Random.Range(1f, 5f);
            var command = new MoveCommandData(speed, _updateTime, direction);
            Debug.Log($"{command.Speed}, {command.UpdateTime}, {command.Direction}");
            _data.Add(command);
            _mover.Set(speed, direction);
        }

        public Queue<MoveCommandData> GetData()
        {
            var d = _data[_data.Count - 1];
            d.UpdateTime = _currentTime;
            _data[_data.Count - 1] = d;
            return new Queue<MoveCommandData>(_data);
        }

        protected override void OnReset()
        {
            _data.Clear();
        }
    }
}
