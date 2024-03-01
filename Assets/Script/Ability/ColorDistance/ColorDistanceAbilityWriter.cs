using UnityEngine;
using VacoTest.Unit;

namespace VacoTest.Ability
{
    public class ColorDistanceAbilityWriter : ColorDistanceAbility
    {
        private AbstractUnit _unit;

        protected override void OnAwake()
        {
            _unit = GetComponent<AbstractUnit>();
            _unit.OnReset += ResetStorage;
        }

        private void OnDestroy()
        {
            _unit.OnReset -= ResetStorage;
        }

        private void ResetStorage() => _storage.ResetCurrentData();

        protected override Color GetColor()
        {
            var color = _config.GetRandomColor();
            _storage.Add(color);
            return color;
        }
    }
}