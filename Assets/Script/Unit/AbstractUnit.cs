using System;
using UnityEngine;
using VacoTest.Command;

namespace VacoTest.Unit
{
    [RequireComponent(typeof(DirectionMover))]
    public abstract class AbstractUnit : MonoBehaviour
    {
        private DirectionMover _mover;
        protected float _currentTime = 0;

        public event Action<float> OnSpeedUpdated;
        public event Action OnReset;

        public abstract float UpdateTime { get; }

        private void Awake()
        {
            _mover = GetComponent<DirectionMover>();
            OnAwake();
        }

        private void OnEnable()
        {
            ResetState();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (IsTimeOut())
            {
                ResetTime();
                UpdateMover();
            }
        }

        public void ResetState()
        {
            transform.position = Vector3.zero;
            OnReset?.Invoke();
            ResetTime();
            UpdateMover();
        }

        private void UpdateMover()
        {
            var data = GetMoveData();
            _mover.Set(data.Speed, data.Direction);
            OnSpeedUpdated?.Invoke(data.Speed);
        }

        private void ResetTime() => _currentTime = 0;
        protected virtual bool IsTimeOut() => _currentTime >= UpdateTime;
        protected virtual void OnAwake() { }
        protected abstract MoveCommandData GetMoveData();
    }
}
