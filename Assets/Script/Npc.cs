using System.Collections.Generic;
using UnityEngine;
using VacoTest.Command;

namespace VacoTest
{
    [RequireComponent(typeof(DirectionMover))]
    public class Npc : Unit
    {
        private bool _isActive = true;
        public MoveCommandData _currentCommand;
        private Queue<MoveCommandData> _data = new Queue<MoveCommandData>();

        public override float UpdateTime => _currentCommand.UpdateTime;

        protected override bool IsTimeOut()
        {
            return _isActive && base.IsTimeOut();
        }

        protected override void UpdateMover()
        {
            UpdateActiveFlag();
            if (_data.Count == 0)
                _currentCommand = new MoveCommandData();
            else
                _currentCommand = _data.Dequeue();

            _mover.Set(_currentCommand.Speed, _currentCommand.Direction);
        }

        public void SetData(Queue<MoveCommandData> data)
        {
            _data = data;
            UpdateActiveFlag();
        }

        private void UpdateActiveFlag()
        {
            _isActive = _data != null && _data.Count > 0;
        }
    }
}