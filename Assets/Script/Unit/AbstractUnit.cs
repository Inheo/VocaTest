using UnityEngine;

namespace VacoTest.Unit
{
    [RequireComponent(typeof(DirectionMover))]
    public abstract class AbstractUnit : MonoBehaviour
    {
        protected DirectionMover _mover;
        protected float _currentTime = 0;

        public abstract float UpdateTime { get; }

        private void Awake()
        {
            _mover = GetComponent<DirectionMover>();
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
            OnReset();
            ResetTime();
            UpdateMover();
        }

        private void ResetTime() => _currentTime = 0;

        protected virtual void OnReset() { }

        protected virtual bool IsTimeOut() => _currentTime >= UpdateTime;

        protected abstract void UpdateMover();
    }
}
