using UnityEngine;
using VacoTest.Ability.Config;
using VacoTest.Unit;

namespace VacoTest.Ability
{
    [RequireComponent(typeof(AbstractUnit))]
    public class ColorSpeedAbility : MonoBehaviour
    {
        [SerializeField] private ColorSpeedAbilityConfig _config;

        private AbstractUnit _unit;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _unit = GetComponent<AbstractUnit>();
            _unit.OnSpeedUpdated += SpeedUpdated;
        }

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