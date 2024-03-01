using System.Collections.Generic;
using UnityEngine;
using VacoTest.Command;

namespace VacoTest.Unit
{
    [RequireComponent(typeof(DirectionMover))]
    public class Npc : AbstractUnit
    {
        private bool _isActive = true;
        private MoveCommandData _currentCommand;
        private Queue<MoveCommandData> _data = new Queue<MoveCommandData>();

        public void SetData(Queue<MoveCommandData> data)
        {
            _data = data;
            UpdateActiveFlag();
        }

        public override float UpdateTime => _currentCommand.UpdateTime;

        protected override bool IsTimeOut() => _isActive && base.IsTimeOut();

        protected override MoveCommandData GetMoveData()
        {
            UpdateActiveFlag();
            if (_data.Count == 0)
                _currentCommand = new MoveCommandData();
            else
                _currentCommand = _data.Dequeue();

            return _currentCommand;
        }

        private void UpdateActiveFlag() => _isActive = _data != null && _data.Count > 0;
    }
}