using UnityEngine;
using VacoTest.Unit;

namespace VacoTest.Ability
{
    public class ColorDistanceAbilityWriter : ColorDistanceAbility
    {
        protected override void OnAwake()
        {
            _unit.OnReset += ResetStorage;
        }

        protected override void OnDestroyed()
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