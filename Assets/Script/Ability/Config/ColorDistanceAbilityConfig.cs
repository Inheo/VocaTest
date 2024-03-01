using UnityEngine;

namespace VacoTest.Ability.Config
{
    [CreateAssetMenu(menuName = "Ability/ColorDistance")]
    public class ColorDistanceAbilityConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 5f)] public float Distance { get; private set; } = 3;

        public float SqrDistance => Distance * Distance;

        public Color GetRandomColor() => Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
    }
}
