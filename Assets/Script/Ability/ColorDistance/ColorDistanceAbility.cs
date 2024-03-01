using UnityEngine;
using VacoTest.Ability.Config;
using VacoTest.Unit;

namespace VacoTest.Ability
{
    public abstract class ColorDistanceAbility : MonoBehaviour
    {
        [SerializeField] protected ColorDistanceAblityConfig _config;
        [SerializeField] protected ColorDistanceAbilityDataStorage _storage;

        private Vector3 _sqrPassedDistance = Vector3.zero;
        private Vector3 _lastVector;
        protected Color _startColor;
        private Renderer _renderer;
        protected AbstractUnit _unit;

        private void Awake()
        {
            _unit = GetComponent<AbstractUnit>();
            _renderer = GetComponent<Renderer>();
            _startColor = _renderer.material.color;
            _unit.OnReset += Reset;
            OnAwake();
        }

        private void Start()
        {
            _lastVector = transform.position;
        }

        private void Reset()
        {
            _sqrPassedDistance = Vector3.zero;
            _lastVector = transform.position;
            _renderer.material.color = _startColor;
        }

        private void Update()
        {
            _sqrPassedDistance += transform.position - _lastVector;
            _lastVector = transform.position;

            if (_sqrPassedDistance.sqrMagnitude >= _config.SqrDistance)
            {
                _sqrPassedDistance = Vector3.zero;
                ChangeColor();
            }
        }

        private void OnDestroy()
        {
            _unit.OnReset -= Reset;
            OnDestroyed();
        }

        private void ChangeColor()
        {
            var color = GetColor();
            _renderer.material.color = color;
        }

        protected virtual void OnDestroyed() { }
        protected virtual void OnAwake() { }
        protected abstract Color GetColor();
    }
}