using UnityEngine;
using VacoTest.Ability.Config;

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

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            OnAwake();
        }

        private void Start()
        {
            _lastVector = transform.position;
            _startColor = _renderer.material.color;
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

        private void ChangeColor()
        {
            var color = GetColor();
            _renderer.material.color = color;
        }

        protected virtual void OnAwake() { }
        protected abstract Color GetColor();
    }
}