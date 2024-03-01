using UnityEngine;
using VacoTest.Ability.Config;
using VacoTest.Unit;

namespace VacoTest.Ability
{
    [RequireComponent(typeof(AbstractUnit))]
    public class ColorSpeedAbility : MonoBehaviour
    {
        [SerializeField] private ColorSpeedAbilityConfig _config;

        protected Color _startColor;
        private Renderer _renderer;
        private AbstractUnit _unit;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _unit = GetComponent<AbstractUnit>();
            _startColor = _renderer.material.color;
            _unit.OnSpeedUpdated += SpeedUpdated;
            _unit.OnReset += ResetColor;
        }

        private void OnDestroy()
        {
            _unit.OnSpeedUpdated -= SpeedUpdated;
            _unit.OnReset -= ResetColor;
        }

        private void ResetColor() => _renderer.material.color = _startColor;

        private void SpeedUpdated(float speed)
        {
            if (speed > _config.SpeedOfChange)
                ChangeColor();
        }

        private void ChangeColor()
        {
            _renderer.material.color = _config.Color;
        }
    }
}