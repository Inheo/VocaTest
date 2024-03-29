using System.Collections.Generic;
using UnityEngine;
using VacoTest.Command;

namespace VacoTest.Unit
{
    public class Player : AbstractUnit
    {
        [SerializeField] private PlayerConfig _config;

        public override float UpdateTime => _config.UpdateTime;

        private List<MoveCommandData> _data = new List<MoveCommandData>();

        protected override MoveCommandData GetMoveData() => GenerateData();

        protected override void OnAwake()
        {
            OnReset += ClearData;
        }

        public Queue<MoveCommandData> GetData()
        {
            CalculateTimeForLastData();
            return new Queue<MoveCommandData>(_data);
        }

        private void ClearData()
        {
            _data.Clear();
        }

        private MoveCommandData GenerateData()
        {
            var command = _config.GetMoveCommandData();
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
