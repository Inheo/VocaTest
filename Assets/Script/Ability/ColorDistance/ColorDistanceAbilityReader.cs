using UnityEngine;

namespace VacoTest.Ability
{
    public class ColorDistanceAbilityReader : ColorDistanceAbility
    {
        protected override Color GetColor()
        {
            var data = _storage.Get();
            var color = data.HasValue ? data.Value.Color : _startColor;
            return color;
        }
    }
}