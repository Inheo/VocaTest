using System.Collections.Generic;
using UnityEngine;
using VacoTest.Command;

namespace VacoTest.Unit
{
    public class Player : AbstractUnit
    {
        [SerializeField] private float _updateTime = 1f;

        public override float UpdateTime => _updateTime;

        private List<MoveCommandData> _data = new List<MoveCommandData>();

        protected override void UpdateMover()
        {
            var command = GenerateData();
            _mover.Set(command.Speed, command.Direction);
        }

        public Queue<MoveCommandData> GetData()
        {
            CalculateTimeForLastData();
            return new Queue<MoveCommandData>(_data);
        }

        protected override void OnReset()
        {
            _data.Clear();
        }

        private MoveCommandData GenerateData()
        {
            var direction = new Vector3(Random.Range(0f, 1f), 0f, Random.Range(0f, 1f)).normalized;
            var speed = Random.Range(1f, 5f);
            var command = new MoveCommandData(speed, _updateTime, direction);
            _data.Add(command);
            return command;
        }

        private void CalculateTimeForLastData()
        {
            var d = _data[_data.Count - 1];
            d.UpdateTime = _currentTime;
            _data[_data.Count - 1] = d;
        }
    }
}
